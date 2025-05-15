using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimesheetTrackerLibrary;
using TimesheetTrackerLibrary.DataAccess;
using TimesheetTrackerLibrary.DataAccess.Dapper;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
	public partial class EditWorkLogForm : Form
	{
		private readonly IRequestData<WorkLogModel> _callingForm;
        private readonly ITimesheetDataAccess _dataAccess;
		private List<WorkLogModel> workLogs = [];
        private List<ProjectModel> projects = [];

		public EditWorkLogForm(IRequestData<WorkLogModel> callingForm, ITimesheetDataAccess dataAccess)
		{
			_callingForm = callingForm;
            _dataAccess = dataAccess;

			InitializeComponent();

            LoadProjects();

			DatePicker.Value = DateTime.Now;
		}

		private void DatePicker_ValueChanged(object sender, EventArgs e)
		{
            LoadWorkLog();
		}

        private void LoadProjects()
        {
            projects = _dataAccess.GetAllProjects();

			ProjectComboBox.DisplayMember = nameof(ProjectModel.LongDisplay);

			if (projects.Count > 0)
			{
				ProjectComboBox.DataSource = projects;
				ProjectComboBox.SelectedIndex = 0;
				ProjectComboBox.Enabled = true;
			}
			else
			{
				ProjectComboBox.SelectedItem = null;
				ProjectComboBox.Enabled = false;
			}
        }

		private void ProjectComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
            LoadWorkLog();
		}

        private void LoadWorkLog()
        {
            var workLog = GetSelectedWorkLog();

			if (workLog is null)
			{
				HoursWorkedTextBox.Text = "";
				NotesTextBox.Text = "";
				WorkLogGroupBox.Enabled = false;
			}
			else
			{
				HoursWorkedTextBox.Text = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(workLog.HoursWorked).ToString(@"hh\:mm");
				NotesTextBox.Text = workLog.Notes;
				WorkLogGroupBox.Enabled = true;
			}
        }

        private WorkLogModel? GetSelectedWorkLog()
        {
            ProjectModel? project = (ProjectModel?)ProjectComboBox.SelectedItem;

            WorkLogModel? workLog = null;
            if (project != null)
            {
                var date = DateOnly.FromDateTime(DatePicker.Value);
                workLog = _dataAccess.GetWorkLog(project.Id, date.ToString("yyyy-MM-dd"));

                if (workLog == null)
                {
                    workLog = new WorkLogModel()
                    {
                        ProjectId = project.Id,
                        Project = project,
                        Date = date.ToString("yyyy-MM-dd"),
                        HoursWorked = 0
                    };
                }
            }

            return workLog;
        }

		private void SaveBtn_Click(object sender, EventArgs e)
		{
            var workLog = GetSelectedWorkLog();

			if (workLog is not null)
			{
				if (TimeSpan.TryParse(HoursWorkedTextBox.Text, out TimeSpan hoursWorkedTimeSpan))
				{
					workLog.HoursWorked = hoursWorkedTimeSpan.TotalHours;
				}
				else
				{
					MessageBox.Show(
						"Hours worked is not in a valid format.",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);

					return;
				}

				workLog.Notes = NotesTextBox.Text;

				_dataAccess.UpsertWorkLog(workLog);

				_callingForm.ReceiveData(workLog);

				MessageBox.Show(
					"The work log was updated successfully.",
					"Success!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		private void HoursWorkedTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsControl(e.KeyChar) == false &&
				char.IsDigit(e.KeyChar) == false)
			{
				e.Handled = true;
				return;
			}

			if (HoursWorkedTextBox.Text.Length == 1 && char.IsDigit(e.KeyChar))
			{
				HoursWorkedTextBox.Text += e.KeyChar;
				HoursWorkedTextBox.Text += ':';
			}
			else if (HoursWorkedTextBox.Text.Length == 3 && e.KeyChar == '\b')
			{
				HoursWorkedTextBox.Text = HoursWorkedTextBox.Text.Substring(0, 1);
			}
			else
			{
				return;
			}
			
			HoursWorkedTextBox.SelectionStart = HoursWorkedTextBox.Text.Length;
			HoursWorkedTextBox.SelectionLength = 0;
			e.Handled = true;
		}
	}
}
