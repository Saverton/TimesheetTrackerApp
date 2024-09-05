using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTrackerLibrary.DataAccess
{
	public static class TimesheetTrackerDataAccess
	{
		private static IDataAccess _database = new SQLiteDataAccess(GlobalConfig.GetConnectionString("Default"));

		public static List<WorkLogModel> GetWorkLogsInDateRange(DateOnly startDate, DateOnly endDate)
		{
			string sql = "SELECT * FROM WorkLogs " +
				"WHERE Date >= @StartDate AND Date <= @EndDate;";

			var output = _database.LoadData<WorkLogModel, dynamic>(sql, new
			{
				StartDate = startDate.ToString("yyyy-MM-dd"),
				EndDate = endDate.ToString("yyyy-MM-dd")
			});

			sql = "SELECT * FROM Projects " +
				"WHERE Id = @ProjectId;";
			foreach (var log in output)
			{
				log.Project = _database.LoadData<ProjectModel, dynamic>(sql, log).First();
			}

			return output;
		}

		public static WorkLogModel UpsertWorkLog(WorkLogModel model)
		{
			if (string.IsNullOrWhiteSpace(model.Notes))
			{
				model.Notes = null;
			}

			string sql = "SELECT * FROM WorkLogs " +
				"WHERE ProjectId = @ProjectId AND Date = @Date";

			var workLog = _database.LoadData<WorkLogModel, dynamic>(sql, model).FirstOrDefault();

			if (workLog is null)
			{
				sql = "INSERT INTO WorkLogs (ProjectId, Date, HoursWorked, Notes) " +
					"VALUES (@ProjectId, @Date, @HoursWorked, @Notes);";

				_database.SaveData(sql, model);

				sql = "SELECT * FROM WorkLogs " +
					"WHERE ProjectId = @ProjectId AND Date = @Date";

				workLog = _database.LoadData<WorkLogModel, dynamic>(sql, model).First();
			}
			else
			{
				sql = "UPDATE WorkLogs " +
					"SET HoursWorked = @HoursWorked, " +
					"Notes = @Notes, " +
					"UpdatedAt = @UpdatedAt " +
					"WHERE Id = @Id";

				workLog.HoursWorked = model.HoursWorked;
				workLog.Notes = model.Notes;
				workLog.UpdatedAt = DateTime.UtcNow;

				_database.SaveData(sql, workLog);
			}

			return workLog;
		}

		public static WorkLogModel? GetWorkLog(int projectId, string date)
		{
			string sql = "SELECT * FROM WorkLogs " +
				"WHERE ProjectId = @ProjectId AND Date = @Date";

			var output = _database.LoadData<WorkLogModel, dynamic>(sql, new
			{
				ProjectId = projectId,
				Date = date
			}).FirstOrDefault();

			return output;
		}

		public static ProjectModel CreateProject(ProjectModel model)
		{
			if (string.IsNullOrWhiteSpace(model.Notes))
			{
				model.Notes = null;
			}

			string sql = "INSERT INTO Projects (ProjectName, ProjectNumber, ProjectPhase, Notes) " +
				"VALUES (@ProjectName, @ProjectNumber, @ProjectPhase, @Notes);";

			_database.SaveData(sql, model);

			sql = "SELECT * FROM Projects " +
				"WHERE ProjectName = @ProjectName AND " +
				"ProjectNumber = @ProjectNumber AND " + 
				"ProjectPhase = @ProjectPhase;";

			var output = _database.LoadData<ProjectModel, dynamic>(sql, model).First();
			return output;
		}

		public static void UpdateProject(ProjectModel model)
		{
			string sql = "UPDATE Projects " +
				"SET ProjectName = @ProjectName, " +
				"ProjectNumber = @ProjectNumber, " +
				"ProjectPhase = @ProjectPhase, " +
				"Notes = @Notes, " +
				"UpdatedAt = @UpdatedAt " +
				"WHERE Id = @Id;";

			model.UpdatedAt = DateTime.UtcNow;

			_database.SaveData<dynamic>(sql, model);
		}

		public static List<ProjectModel> GetAllProjects()
		{
			string sql = "SELECT * FROM Projects;";

			var output = _database.LoadData<ProjectModel, dynamic>(sql, new { });
			return output;
		}
	}
}
