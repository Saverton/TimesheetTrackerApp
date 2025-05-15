using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary.Models
{
	public class ProjectModel
	{
		public int Id { get; set; }
		public string ProjectName { get; set; } = string.Empty;
		public string ProjectNumber { get; set; } = string.Empty;
		public string? ProjectPhase { get; set; }
		public string? Notes { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public string ShortDisplay => ProjectNumberPhase;

        public string LongDisplay => $"{ProjectName} ({ProjectNumberPhase})";

        private string ActiveDisplay => IsActive ? "\u2713" : "_";

        public string FullDisplay => $"{ActiveDisplay} {ProjectName} ({ProjectNumberPhase})";

        public string ProjectNumberPhase => ProjectPhase != null 
            ? $"{ProjectNumber}.{ProjectPhase}"
            : ProjectNumber;

		public override string ToString()
		{
			return LongDisplay;
		}
	}
}
