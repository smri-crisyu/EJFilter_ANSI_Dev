
using EJFilter.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models
{
    public class EJCommonDBContext : DbContext
    {
        public EJCommonDBContext() : base("EJCommon")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<DBSettings> DBSettings { get; set; }
       
        public DbSet<ScheduleSettings> ScheduleSettings { get; set; }

    }
}
