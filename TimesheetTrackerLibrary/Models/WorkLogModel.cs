using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary.Models
{
	public class WorkLogModel
	{
		public int Id { get; set; }
		public int ProjectId { get; set; }
		public ProjectModel? Project { get; set; }
		public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
		public double HoursWorked { get; set; }
		public string? Notes { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string ProjectDisplay 
		{ 
			get => Project?.LongDisplay ?? $"Project Id: {ProjectId}"; 
		}

		public override string ToString()
		{
			var timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(HoursWorked);

			return timeSpan.ToString(@"hh\:mm");
		}
	}
}
