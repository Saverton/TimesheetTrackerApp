using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary.Models
{
    public class OldWorkLogModel
    {
		public int Id { get; set; }
		public int ProjectId { get; set; }
		public ProjectModel? Project { get; set; }
		public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
		public double HoursWorked { get; set; }
		public string? Notes { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
    }
}
