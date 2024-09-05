using System.ComponentModel;
using TimesheetTrackerLibrary;
using TimesheetTrackerLibrary.DataAccess;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
	public partial class DashboardForm : Form, IRequestData<ProjectModel>, IRequestData<WorkLogModel>
    {
        private readonly BindingList<ProjectModel> projects = new BindingList<ProjectModel>(TimesheetTrackerDataAccess.GetAllProjects());
        private TimeSpan _timeSpan = TimeSpan.Zero;
        private bool _isTimerRunning = false;
        private bool _isWorkSaved = true;
        private ProjectModel? _currentProject;
        private bool _isForceClose = false;

        public DashboardForm()
        {
            InitializeComponent();

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
                if (_isTimerRunning == false && _isWorkSaved == false)
                {
                    SaveBtn.Enabled = true;
                }
                EditProjectLink.Enabled = true;
            }
        }

        private void WireUpLists()
        {
            ProjectsComboBox.DataSource = projects;
            ProjectsComboBox.DisplayMember = "ProjectName";
        }

        private void AddProjectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new ProjectForm(this);
            form.ShowDialog();
        }

        public void ReceiveData(ProjectModel project)
        {
            int projectIndex = GetProjectIndex(project);

            if (projectIndex == -1)
            {
                projects.Add(project);
                projectIndex = projects.Count - 1;
            }

            ProjectsComboBox.SelectedIndex = projectIndex;

            EditProjectLink.Enabled = true;
            TimerControlBtn.Enabled = true;
            NotesTextBox.Enabled = true;
        }

        private void EditProjectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var selectedProject = ProjectsComboBox.SelectedItem as ProjectModel;

            if (selectedProject is not null)
            {
                var form = new ProjectForm(this, selectedProject);
                form.ShowDialog();
            }
        }

        private void TimerControlBtn_Click(object sender, EventArgs e)
        {
            SetTimerRunning(!_isTimerRunning);
        }

        private void SetTimerRunning(bool value)
        {
            if (value)
            {
                Timer.Start();
                TimerControlBtn.Text = "Stop";
                _isTimerRunning = true;
            }
            else
            {
                Timer.Stop();
                TimerControlBtn.Text = "Start";
                _isTimerRunning = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
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
                this.SaveWorkLog();
            }

            if (selectedProject?.Id != _currentProject?.Id)
            {
                _currentProject = ProjectsComboBox.SelectedValue as ProjectModel;

                if (_currentProject is not null)
                {
                    var workLog = TimesheetTrackerDataAccess.GetWorkLog(_currentProject.Id, DateTime.Now.ToString("yyyy-MM-dd"));

                    if (workLog is not null)
                    {
                        NotesTextBox.Text = workLog.Notes;
                        _timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(workLog.HoursWorked);
                        TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");
                        _isWorkSaved = true;
                        return;
                    }
                }

                _timeSpan = TimeSpan.Zero;
                TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");

                NotesTextBox.Text = string.Empty;
            }
        }

        private int GetProjectIndex(ProjectModel project)
        {
            int output = -1;
            for (int i = 0; i < projects.Count; i++)
            {
                if (projects[i].Id == project.Id)
                {
                    output = i;
                    projects[i] = project;
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
                Notes = NotesTextBox.Text
            };

            TimesheetTrackerDataAccess.UpsertWorkLog(workLog);

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
            var form = new EditWorkLogForm(this);
            form.ShowDialog();
        }

        private void timesheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ensures data displayed is the most up-to-date
            SaveWorkLog();

            var form = new TimesheetViewerForm();
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isForceClose = true;
            Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.ShowDialog();
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && _isForceClose == false)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                return;
            }

            if (_isForceClose == true && _isWorkSaved == false)
            {
                SetTimerRunning(false);
                SaveWorkLog();
            }
        }

        private void DashboardForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                TimesheetTrackerMinimizeNotifyIcon.Visible = true;
                TimesheetTrackerMinimizeNotifyIcon.ShowBalloonTip(3000,
                     "Minimized Timesheet Tracker",
                      "The Timesheet Tracker app will continue to run in the background.",
                      ToolTipIcon.Info);
            }
        }

        private void TimesheetTrackerMinimizeNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void TimesheetTrackerMinimizeNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
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
            if (data.ProjectId == _currentProject?.Id && DateOnly.Parse(data.Date) == DateOnly.FromDateTime(DateTime.Now))
            {
                NotesTextBox.Text = data.Notes;
				_timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(data.HoursWorked);
				TimerLabel.Text = _timeSpan.ToString(@"hh\:mm\:ss");
				_isWorkSaved = true;
            }
		}
	}
}
