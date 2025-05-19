using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetTrackerLibrary.DataAccess.Dapper;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTrackerLibrary.DataAccess.EFCore
{
    /// <summary>
    /// This is a very specific use case class that migrates the old Dapper database schema to a newly
    /// created EF Core created database with migrations. The only reason this is necessary is to ensure databases are
    /// in sync with migratoins wihtout dropping everything and rebuilding.
    /// </summary>
    public static class DapperToEFCoreMigrator
    {
        public static void MigrateDapperToEFCore(IServiceProvider services)
        {
            var oldDb = services.GetRequiredService<IDataAccess>();
            using var newDb = services.GetRequiredService<TimesheetTrackerDbContext>();

            // build migration models
            string sql = "SELECT * from Projects";
            var allProjects = oldDb.LoadData<OldProjectModel, dynamic>(sql, new { });

            sql = "SELECT * from WorkLogs WHERE ProjectId = @ProjectId";
            Dictionary<int, List<OldWorkLogModel>> projectsToWorkLogs = [];
            foreach (var project in allProjects)
            {
                projectsToWorkLogs[project.Id] = oldDb.LoadData<OldWorkLogModel, dynamic>(sql, new { ProjectId = project.Id });
            }

            // migrate
            foreach (var oldProject in allProjects)
            {
                ProjectModel newProject = new()
                { 
                    ProjectName = oldProject.ProjectName,
                    ProjectNumber = oldProject.ProjectNumber,
                    ProjectPhase = oldProject.ProjectPhase,
                    Notes = oldProject.Notes,
                    CreatedAt = oldProject.CreatedAt,
                    UpdatedAt = oldProject.UpdatedAt,
                    IsActive = true
                };

                newDb.Add(newProject);

                foreach (var oldWorkLog in projectsToWorkLogs[oldProject.Id])
                {
                    WorkLogModel newWorkLog = new()
                    {
                        Project = newProject,
                        Date = DateOnly.Parse(oldWorkLog.Date),
                        HoursWorked = oldWorkLog.HoursWorked,
                        Notes = oldWorkLog.Notes,
                        CreatedAt = oldWorkLog.CreatedAt,
                        UpdatedAt = oldWorkLog.UpdatedAt,
                    };

                    newDb.Add(newWorkLog);
                }
            }

            newDb.SaveChanges();
        }
    }
}
