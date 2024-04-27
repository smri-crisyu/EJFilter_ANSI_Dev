using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    [Table("Master_Company")]
    public class MasterCompany
    {
        [Key]
        public int CompanyId { get; set; }
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
    }
}
