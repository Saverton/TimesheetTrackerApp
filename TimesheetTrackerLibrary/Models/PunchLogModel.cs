using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary.Models
{
    public class PunchLogModel
    {
        public int Id { get; set; }
        public int WorkLogId { get; set; }
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public WorkLogModel? WorkLog { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
