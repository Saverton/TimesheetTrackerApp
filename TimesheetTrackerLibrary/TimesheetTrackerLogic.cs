using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary
{
	public static class TimesheetTrackerLogic
	{
		public static TimeSpan GetTimeSpanFromHoursWorked(double hoursWorked)
		{
			double r = hoursWorked;
			int hours = (int)r;
			r = (r - hours) * 60;
			int minutes = (int)r;
			r = (r - minutes) * 60;
			int seconds = (int)r;

			return new TimeSpan(hours, minutes, seconds);
		}

		public static string ToHoursMinutesString(this TimeSpan timeSpan)
		{
			int totalHours = (int)timeSpan.TotalHours;

			string hoursString = totalHours.ToString().PadLeft(2, '0');
			string minutesString = timeSpan.Minutes.ToString().PadLeft(2, '0');

			return $"{hoursString}:{minutesString}";
		}
	}
}
