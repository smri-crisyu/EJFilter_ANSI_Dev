using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Scheduler
{
    public class ConfigurationVM
    {
        public string OriginalEJFolderPath { get; set; }
        public string GenerateEJFolderPath { get; set; }
        public string FTPUrl { get; set; }
    }
}
