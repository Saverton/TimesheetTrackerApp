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
		public string ProjectPhase { get; set; } = string.Empty;
		public string? Notes { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public string ShortDisplay
		{
			get => $"{ProjectNumber}.{ProjectPhase}";
		}

		public string LongDisplay
		{
			get => $"{ProjectName} ({ShortDisplay})";
		}

		public override string ToString()
		{
			return ShortDisplay;
		}
	}
}
