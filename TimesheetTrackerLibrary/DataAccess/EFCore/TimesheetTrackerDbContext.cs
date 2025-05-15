using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTrackerLibrary.DataAccess.EFCore
{
    public class TimesheetTrackerDbContext : DbContext
    {
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<WorkLogModel> WorkLogs { get; set; }

        public string DbPath { get; }

        public TimesheetTrackerDbContext()
        {
            DbPath = SqliteLocationProvider.GetSqlitePath();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");
    }
}
