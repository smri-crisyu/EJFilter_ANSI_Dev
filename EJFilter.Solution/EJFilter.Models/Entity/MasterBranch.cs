using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    [Table("Master_Branch")]
    public class MasterBranch
    {
        [Key]
        public int BranchId { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public int StoreCode { get; set; }
    }
}
