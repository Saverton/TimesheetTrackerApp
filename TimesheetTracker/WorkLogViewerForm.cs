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
using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
	public partial class WorkLogViewerForm : Form
	{
		public WorkLogViewerForm(WorkLogModel workLog)
		{
			InitializeComponent();

			ProjectLabel.Text = workLog.Project!.LongDisplay;
			DatePicker.Value = DateTime.Parse(workLog.Date);
			HoursWorkedTextBox.Text = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(workLog.HoursWorked).ToString(@"hh\:mm");
			NotesTextBox.Text = workLog.Notes ?? "(no notes)";
		}
	}
}
