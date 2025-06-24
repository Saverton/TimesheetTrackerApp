using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.InteropServices;
using TimesheetTrackerLibrary;
using TimesheetTrackerLibrary.DataAccess;
using TimesheetTrackerLibrary.DataAccess.Dapper;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
    public partial class DashboardForm : Form, IRequestData<ProjectModel>, IRequestData<WorkLogModel>
    {
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_ENDSESSION = 0x0016;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShutdownBlockReasonDestroy(IntPtr hWnd);

        private readonly ITimesheetDataAccess _dataAccess;

        private BindingList<ProjectModel> _projects;
        private TimeSpan _timeSpan = TimeSpan.Zero;
        private DateOnly _dateToSave = DateOnly.FromDateTime(DateTime.Now);
        private bool _isTimerRunning = false;
        private bool _isWorkSaved = true;
        private ProjectModel? _currentProject;
        private ProjectManagerForm? _projectManagerForm;
        private bool _shouldTimerResume = false;
        private PunchLogModel? _currentPunch;

        public DashboardForm(ITimesheetDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            InitializeComponent();

            _projects = new(_dataAccess.GetAllProjects());

            WireUpLists();

            TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");
            TimerControlBtn.Text = "Start";
            Timer.Enabled = false;

            _currentProject = ProjectsComboBox.SelectedValue as ProjectModel;

            if (_currentProject is null)
            {
                TimerControlBtn.Enabled = false;
                NotesTextBox.Enabled = false;
                SaveBtn.Enabled = false;
                EditProjectLink.Enabled = false;
            }
            else
            {
                TimerControlBtn.Enabled = true;
                NotesTextBox.Enabled = true;
                if (_isWorkSaved == false)
                {
                    SaveBtn.Enabled = true;
                }
                EditProjectLink.Enabled = true;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
            {
                if (_isWorkSaved == false)
                {
                    SetTimerRunning(false);
                    SaveWorkLog();
                }
            }

            base.WndProc(ref m);
        }

        private void WireUpLists()
        {
            ProjectsComboBox.DataSource = _projects;
            ProjectsComboBox.DisplayMember = nameof(ProjectModel.LongDisplay);
        }

        public void ReceiveData(ProjectModel project)
        {
            int projectIndex = GetProjectIndex(project);

            if (projectIndex == -1)
            {
                _projects.Add(project);
                projectIndex = _projects.Count - 1;
            }

            ProjectsComboBox.SelectedIndex = projectIndex;
        }

        private void EditProjectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenProjectManagerForm();
        }

        private void TimerControlBtn_Click(object sender, EventArgs e)
        {
            SetTimerRunning(!_isTimerRunning);
        }

        private void SetTimerRunning(bool value)
        {
            if (value)
            {
                StartPunch();
                Timer.Start();
                TimerControlBtn.Text = "Stop";
                _isTimerRunning = true;
            }
            else
            {
                EndPunch();
                Timer.Stop();
                TimerControlBtn.Text = "Start";
                _isTimerRunning = false;
            }
        }

        private void StartPunch()
        {
            if (_currentPunch != null)
                throw new Exception($"Previous {nameof(_currentPunch)} was not disposed of");

            _currentPunch = new PunchLogModel
            {
                StartTime = DateTime.Now,
            };
        }

        private void EndPunch()
        {
            if (_currentPunch == null)
                return;
            if (_currentProject == null)
                throw new Exception($"{nameof(_currentProject)} is null");

            SaveWorkLog();
            var workLog = _dataAccess.GetWorkLog(
                _currentProject.Id,
                DateOnly.FromDateTime(DateTime.Now))!;
            _currentPunch.EndTime = DateTime.Now;
            _currentPunch.WorkLogId = workLog.Id;

            _dataAccess.UpsertPunchLog(_currentPunch);
            _currentPunch = null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // handle timer running into the next day
            var today = DateOnly.FromDateTime(DateTime.Now);
            if (_dateToSave != today)
            {
                this.SaveWorkLog();
                _dateToSave = today;
                _timeSpan = TimeSpan.Zero;
            }

            _timeSpan = _timeSpan.Add(new TimeSpan(0, 0, 1));
            TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");
            MarkWorkAsUnsaved();
        }

        private void ProjectsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ProjectModel? selectedProject = ProjectsComboBox.SelectedValue as ProjectModel;

            // check if current timer needs to be saved
            if (selectedProject?.Id != _currentProject?.Id &&
                _isWorkSaved == false &&
                _currentProject is not null)
            {
                SaveWorkLog();
            }

            if (_currentPunch != null)
            {
                EndPunch();
            }

            if (selectedProject?.Id != _currentProject?.Id)
            {
                _currentProject = ProjectsComboBox.SelectedValue as ProjectModel;

                if (_currentProject is not null)
                {
                    EditProjectLink.Enabled = true;
                    TimerControlBtn.Enabled = true;
                    NotesTextBox.Enabled = true;

                    if (_shouldTimerResume)
                    {
                        SetTimerRunning(true);
                        _shouldTimerResume = false;
                    }

                    var workLog = _dataAccess.GetWorkLog(_currentProject.Id, DateOnly.FromDateTime(DateTime.Now));

                    if (workLog is not null)
                    {
                        NotesTextBox.Text = workLog.Notes;
                        _timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(workLog.HoursWorked);
                        TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");
                        _isWorkSaved = true;
                        return;
                    }
                }
                else
                {
                    EditProjectLink.Enabled = false;
                    TimerControlBtn.Enabled = false;
                    NotesTextBox.Enabled = false;
                    _shouldTimerResume = _isTimerRunning;
                    SetTimerRunning(false);
                }

                _timeSpan = TimeSpan.Zero;
                TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");

                NotesTextBox.Text = string.Empty;
            }
        }

        private int GetProjectIndex(ProjectModel project)
        {
            int output = -1;
            for (int i = 0; i < _projects.Count; i++)
            {
                if (_projects[i].Id == project.Id)
                {
                    output = i;
                    _projects[i] = project;
                    break;
                }
            }

            return output;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveWorkLog();
        }

        private void SaveWorkLog()
        {
            if (_currentProject is null)
            {
                return;
            }

            WorkLogModel workLog = new()
            {
                ProjectId = _currentProject.Id,
                HoursWorked = _timeSpan.TotalHours,
                Notes = NotesTextBox.Text,
                Date = _dateToSave,
            };

            _dataAccess.UpsertWorkLog(workLog);

            _isWorkSaved = true;
            SaveBtn.Enabled = false;
        }

        private void NotesTextBox_TextChanged(object sender, EventArgs e)
        {
            MarkWorkAsUnsaved();
        }

        private void MarkWorkAsUnsaved()
        {
            _isWorkSaved = false;
            SaveBtn.Enabled = true;
        }

        private void workLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EditWorkLogForm(this, _dataAccess);
            form.ShowDialog();
        }

        private void timesheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ensures data displayed is the most up-to-date
            SaveWorkLog();

            var form = Program.ServiceProvider.GetRequiredService<TimesheetViewerForm>();
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<SettingsForm>();
            form.ShowDialog();
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isWorkSaved == false)
            {
                var result = MessageBox.Show("Would you like to save before exiting? Cancel if you don't want to exit.",
                    "Exiting Timesheet Tracker",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    SaveWorkLog();
                    if (_currentProject != null)
                    {
                        EndPunch();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            SetTimerRunning(false);
        }

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveWorkLog();
            }
        }

        public void ReceiveData(WorkLogModel data)
        {
            if (data.ProjectId == _currentProject?.Id && data.Date == DateOnly.FromDateTime(DateTime.Now))
            {
                NotesTextBox.Text = data.Notes;
                _timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(data.HoursWorked);
                TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");
                _isWorkSaved = true;
            }
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProjectManagerForm();
        }

        private void OpenProjectManagerForm()
        {
            _projectManagerForm ??= Program.ServiceProvider.GetRequiredService<ProjectManagerForm>();
            _projectManagerForm.ShowDialog();

            var oldSelected = ProjectsComboBox.SelectedValue as ProjectModel;

            _projects = new(_dataAccess.GetAllProjects());
            WireUpLists();

            if (oldSelected != null)
            {
                var selectedProject = _projects.FirstOrDefault(prj => prj.Id == oldSelected.Id);

                if (selectedProject != null)
                {
                    var selectedIdx = _projects.IndexOf(selectedProject);
                    ProjectsComboBox.SelectedIndex = selectedIdx;
                }
                else
                {
                    ProjectsComboBox.SelectedIndex = -1;
                }
            }
        }
    }
}
