using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimesheetTrackerLibrary.DataAccess;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
	public partial class ProjectForm : Form
	{
		private readonly IRequestData<ProjectModel> _callingForm;
		private int _projectId;

		public ProjectForm(IRequestData<ProjectModel> callingForm, ProjectModel? project = null)
		{
			InitializeComponent();

			_callingForm = callingForm;

			if (project is not null)
			{
				_projectId = project.Id;
				ProjectNameTextBox.Text = project.ProjectName;
				ProjectNumberTextBox.Text = project.ProjectNumber;
				ProjectPhaseTextBox.Text = project.ProjectPhase;
				NotesTextBox.Text = project.Notes;
			}
			else
			{
				_projectId = 0;
			}
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			ProjectModel project = new()
			{
				ProjectName = ProjectNameTextBox.Text,
				ProjectNumber = ProjectNumberTextBox.Text,
				ProjectPhase = ProjectPhaseTextBox.Text,
				Notes = NotesTextBox.Text,
			};

			if (_projectId == 0)
			{
				project = TimesheetTrackerDataAccess.CreateProject(project);
			}
			else
			{
				project.Id = _projectId;
				TimesheetTrackerDataAccess.UpdateProject(project);
			}

			_callingForm.ReceiveData(project);
			Hide();
		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
