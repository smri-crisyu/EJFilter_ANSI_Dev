using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    public class ScheduleSettings
    {
        [Key]
        public int ScheduleId { get; set; }
        public int DBId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int RunningStatus { get; set; }

        public DateTime TransactionDate { get; set; }

      //  public  DBSettings DBSettings { get; set; }
    }
}
