using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public double HoursWorked { get; set; }
		public string? Notes { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
        public List<PunchLogModel> PunchLogs { get; set; } = [];
        [NotMapped]
		public string ProjectDisplay => Project?.LongDisplay ?? $"Project Id: {ProjectId}"; 

		public override string ToString()
		{
			var timeSpan = TimesheetTrackerLogic.GetTimeSpanFromHoursWorked(HoursWorked);

			return timeSpan.ToString(@"hh\:mm");
		}
	}
}
