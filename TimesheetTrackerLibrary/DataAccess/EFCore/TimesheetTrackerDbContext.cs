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
        public DbSet<PunchLogModel> PunchLogs { get; set; }

        public TimesheetTrackerDbContext() : base() { }
        public TimesheetTrackerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
