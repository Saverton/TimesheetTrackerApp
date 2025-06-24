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
	public partial class WorkLogViewerForm : Form
	{
        private readonly ITimesheetDataAccess _dataAccess;

        private DataTable _punchLogsDataTable = new();
        private BindingSource _punchLogsBindingSource = new();

        public WorkLogViewerForm(ITimesheetDataAccess dataAccess, WorkLogModel workLog)
		{
            _dataAccess = dataAccess;

			InitializeComponent();

			ProjectDisplayTextBox.Text = workLog.Project!.LongDisplay;
			DatePicker.Value = new DateTime(workLog.Date, TimeOnly.MinValue);
			HoursWorkedTextBox.Text = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(workLog.HoursWorked).ToString(@"hh\:mm\:ss");
			NotesTextBox.Text = workLog.Notes ?? "(no notes)";

            _punchLogsBindingSource.DataSource = _punchLogsDataTable;
            PunchLogsDataGrid.DataSource = _punchLogsBindingSource;
            InitGridDisplay(workLog.PunchLogs);
        }

        private void InitGridDisplay(List<PunchLogModel> punchLogs)
        {
            _punchLogsDataTable.Rows.Clear();
            _punchLogsDataTable.Columns.Clear();

            _punchLogsDataTable.Columns.Add(new DataColumn("Start", typeof(DateTime)));
            _punchLogsDataTable.Columns.Add(new DataColumn("End", typeof(DateTime)));
            _punchLogsDataTable.Columns.Add(new DataColumn("Duration", typeof(TimeSpan)));

            foreach (var log in punchLogs)
            {
                object?[] row = [log.StartTime, log.EndTime, log.EndTime - log.StartTime];
                _punchLogsDataTable.Rows.Add(row);
            }

            _punchLogsDataTable.AcceptChanges();

            PunchLogsDataGrid.Columns[0].Width = 200;
            PunchLogsDataGrid.Columns[0].DefaultCellStyle.Format = "h:mm:ss tt";
            PunchLogsDataGrid.Columns[1].Width = 200;
            PunchLogsDataGrid.Columns[1].DefaultCellStyle.Format = "h:mm:ss tt";
            PunchLogsDataGrid.Columns[2].Width = 200;
            PunchLogsDataGrid.Columns[2].DefaultCellStyle.Format = "h':'mm':'ss";
        }
	}
}
