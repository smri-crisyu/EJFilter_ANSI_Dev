using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    [Table("Master_Store")]
    public  class MasterStore
    {
        [Key]
        public int StoreId { get; set; }
        public int StoreCode { get; set; }
        public string StoreName { get; set; }
    }
}
