using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EJFilter.Models.Entity
{
    [Table("DB_Credentials")]
    public class DBCredentials
    {
        [Key]
        public int Id { get; set; }
        public string DBName { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }
    }
}
