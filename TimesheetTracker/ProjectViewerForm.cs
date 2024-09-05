using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
	public partial class ProjectViewerForm : Form
	{
		public ProjectViewerForm(ProjectModel project)
		{
			InitializeComponent();

			ProjectNameLabel.Text = project.ProjectName;
			ProjectNumberLabel.Text = project.ProjectNumber;
			ProjectPhaseLabel.Text = project.ProjectPhase;
			NotesTextBox.Text = project.Notes ?? "(no notes)";
		}
	}
}
