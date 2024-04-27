using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    [Table("Config_Type")]
    public class ConfigTypes
    {
        [Key]
        public int Id { get; set; }
        public string ConfigName { get; set; }
        public string Type { get; set; }
    }
}
