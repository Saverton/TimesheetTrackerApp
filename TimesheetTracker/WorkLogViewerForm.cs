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

			ProjectDisplayTextBox.Text = workLog.Project!.LongDisplay;
			DatePicker.Value = new DateTime(workLog.Date, TimeOnly.MinValue);
			HoursWorkedTextBox.Text = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(workLog.HoursWorked).ToString(@"hh\:mm\:ss");
			NotesTextBox.Text = workLog.Notes ?? "(no notes)";
		}
	}
}
