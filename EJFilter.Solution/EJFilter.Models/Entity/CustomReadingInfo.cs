using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    public class CustomReadingInfo
    {
        public string RowField { get; set; }
        public string LastTransact { get; set; }

        public bool LastXReading { get; set; }

        public string ReadingType { get; set; }
        public string CashierCode { get; set; }

    }
}
