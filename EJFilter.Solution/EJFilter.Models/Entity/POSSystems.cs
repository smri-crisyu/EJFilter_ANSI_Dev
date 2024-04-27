using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    [Table("POS_Systems")]
    public class POSSystem
    {
        [Key]
        public int Id { get; set; }
        public string POSType { get; set; }
    }
}
