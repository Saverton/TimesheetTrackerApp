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
	public partial class TimesheetViewerForm : Form
	{
		private readonly List<int> years = [];
		private List<WeekModel> weeks = [];
		private List<WorkLogModel> workLogs = [];
		private DataTable timesheetTable = new();
		private BindingSource timesheetBindingSource = new();

		public TimesheetViewerForm()
		{
			InitializeComponent();

			DateTimeGeneratedLabel.Text = "generated at " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

			LoadYears();

			timesheetBindingSource.DataSource = timesheetTable;
			TimesheetDataGrid.DataSource = timesheetBindingSource;
			TimesheetDataGrid.CellMouseDoubleClick += OnCellDoubleClick;
		}

		private void LoadYears()
		{
			for (int i = 2024; i <= DateTime.Now.Year; i++)
			{
				years.Add(i);
			}

			YearComboBox.DataSource = years;
			YearComboBox.SelectedIndex = years.Count - 1;
		}

		private void LoadWeeks(int year)
		{
			weeks.Clear();
			var weekTime = new DateOnly(year, 1, 1);

			while (weekTime.DayOfWeek != DayOfWeek.Sunday)
			{
				weekTime = weekTime.AddDays(-1);
			}

			while (weekTime.Year <= year &&
				weekTime.CompareTo(DateOnly.FromDateTime(DateTime.Now)) == -1)
			{
				WeekModel week = new()
				{
					StartDate = weekTime,
					EndDate = weekTime.AddDays(6),
				};

				weeks.Add(week);

				weekTime = weekTime.AddDays(7);
			}

			WeekComboBox.DataSource = weeks;
			WeekComboBox.DisplayMember = nameof(WeekModel.Display);

			if (year == DateTime.Now.Year)
			{
				WeekComboBox.SelectedIndex = weeks.Count - 1;
			}
			else
			{
				WeekComboBox.SelectedIndex = 0;
			}
		}

		sealed class WeekModel
		{
			public DateOnly StartDate { get; set; }
			public DateOnly EndDate { get; set; }
			public string Display
			{
				get => $"{StartDate.ToString("MM/dd")} - {EndDate.ToString("MM/dd")}";
			}
		}

		private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int? year = (int?)YearComboBox.SelectedItem;

			LoadWeeks(year ?? DateTime.Now.Year);
		}

		private void WeekComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			WeekModel? week = (WeekModel?)WeekComboBox.SelectedItem;

			if (week is null)
			{
				return;
			}

			workLogs.Clear();
			workLogs = TimesheetTrackerDataAccess.GetWorkLogsInDateRange(week.StartDate, week.EndDate);

			timesheetTable.Rows.Clear();
			timesheetTable.Columns.Clear();

			var col = new DataColumn("Projects", typeof(object));
			timesheetTable.Columns.Add(col);

			for (DateOnly day = week.StartDate; day.CompareTo(week.EndDate) <= 0; day = day.AddDays(1))
			{
				col = new DataColumn(day.ToString("ddd\nMM/dd"), typeof(object));
				timesheetTable.Columns.Add(col);
			}

			col = new DataColumn("Total", typeof(object));
			timesheetTable.Columns.Add(col);

			var logsByProject = workLogs.GroupBy(x => x.ProjectId);

			double totalHours = 0;
			Dictionary<DayOfWeek, double> totalHoursByDay = new();

			foreach (var projectLogs in logsByProject)
			{
				List<object?> row = [projectLogs.First().Project!.LongDisplay];

				double totalHoursThisWeek = 0;

				for (DateOnly day = week.StartDate; day.CompareTo(week.EndDate) <= 0; day = day.AddDays(1))
				{
					var log = projectLogs.FirstOrDefault(x => x.Date == day.ToString("yyyy-MM-dd"));

					if (log is not null)
					{
						var timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(log.HoursWorked);
						row.Add(log);
						totalHoursThisWeek += log.HoursWorked;

						if (totalHoursByDay.TryGetValue(day.DayOfWeek, out double totalHoursThisDay))
						{
							totalHoursByDay[day.DayOfWeek] += log.HoursWorked;
						}
						else
						{
							totalHoursByDay.Add(day.DayOfWeek, log.HoursWorked);
						}
					}
					else
					{
						row.Add(null);
					}
				}

				totalHours += totalHoursThisWeek;
				var timeSpanThisWeek = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(totalHoursThisWeek);
				row.Add(timeSpanThisWeek.ToHoursMinutesString());

				timesheetTable.Rows.Add(row.ToArray());
			}

			var timeSpanTotal = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(totalHours);
			List<string> totalRow = ["Total"];
			foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
			{
				double hoursWorked = totalHoursByDay.GetValueOrDefault(dayOfWeek);
				var timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(hoursWorked);
				if (timeSpan.CompareTo(TimeSpan.Zero) > 0)
				{
					totalRow.Add(timeSpan.ToString(@"hh\:mm"));
				}
				else
				{
					totalRow.Add("");
				}
			}
			totalRow.Add(timeSpanTotal.ToHoursMinutesString());

			timesheetTable.Rows.Add(totalRow.ToArray());

			timesheetTable.AcceptChanges();

		}

		private void OnCellDoubleClick(object? sender, DataGridViewCellMouseEventArgs? e)
		{
			if (e is null)
			{
				return;
			}

			var cell = TimesheetDataGrid.CurrentCell;

			if (cell.Value is ProjectModel project)
			{
				var form = new ProjectViewerForm(project);
				form.ShowDialog();
			}
			else if (cell.Value is WorkLogModel workLog)
			{
				var form = new WorkLogViewerForm(workLog);
				form.ShowDialog();
			}
		}
	}
}
