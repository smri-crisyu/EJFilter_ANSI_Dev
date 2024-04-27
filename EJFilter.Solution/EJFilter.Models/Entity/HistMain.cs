using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    public class HistMain
    {
        public string Transact { get; set; }
        public string Register { get; set; }

        public DateTime TranDate { get; set; }
        public string Branch { get; set; }

        [NotMapped]
        public string SalesInvoice { get; set; }

        [NotMapped]
        public string IsDuplicate { get; set; }

        [NotMapped]
        public bool HasMissing { get; set; } = true;
    }
}
