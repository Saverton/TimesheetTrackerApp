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
using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
	public partial class EditWorkLogForm : Form
	{
		private readonly IRequestData<WorkLogModel> _callingForm;
		List<WorkLogModel> workLogs = [];

		public EditWorkLogForm(IRequestData<WorkLogModel> callingForm)
		{
			_callingForm = callingForm;

			InitializeComponent();

			ProjectComboBox.DisplayMember = nameof(WorkLogModel.ProjectDisplay);

			LoadWorkLogs();

			DatePicker.Value = DateTime.Now;
		}

		private void DatePicker_ValueChanged(object sender, EventArgs e)
		{
			LoadWorkLogs();
		}

		private void LoadWorkLogs()
		{
			DateOnly date = DateOnly.FromDateTime(DatePicker.Value);
			workLogs = TimesheetTrackerDataAccess.GetWorkLogsInDateRange(date, date);


			if (workLogs.Count > 0)
			{
				ProjectComboBox.DataSource = workLogs;
				ProjectComboBox.SelectedIndex = 0;
				ProjectComboBox.Enabled = true;
			}
			else
			{
				ProjectComboBox.SelectedItem = null;
				ProjectComboBox.Enabled = false;
				WorkLogGroupBox.Enabled = false;
			}
		}

		private void ProjectComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			WorkLogModel? selected = (WorkLogModel?)ProjectComboBox.SelectedItem;

			if (selected is null)
			{
				HoursWorkedTextBox.Text = "";
				NotesTextBox.Text = "";
				WorkLogGroupBox.Enabled = false;
			}
			else
			{
				HoursWorkedTextBox.Text = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(selected.HoursWorked).ToString(@"hh\:mm");
				NotesTextBox.Text = selected.Notes;
				WorkLogGroupBox.Enabled = true;
			}
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			WorkLogModel? selected = (WorkLogModel?)ProjectComboBox.SelectedItem;

			if (selected is not null)
			{
				if (TimeSpan.TryParse(HoursWorkedTextBox.Text, out TimeSpan hoursWorkedTimeSpan))
				{
					selected.HoursWorked = hoursWorkedTimeSpan.TotalHours;
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

				selected.Notes = NotesTextBox.Text;

				TimesheetTrackerDataAccess.UpsertWorkLog(selected);

				_callingForm.ReceiveData(selected);

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
