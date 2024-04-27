using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models
{
    [Table("CONFIG_VQPBOS")]
    public class HeaderFooterVQPBOS
    {
        [Key]
        public int Id { get; set; }
        public int BranchCode { get; set; }
        public int StoreCode { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string ZIP_Code { get; set; }
        public string VatRegTin_H { get; set; }
        public string POS_No { get; set; }
        public string SN_No { get; set; }
        public string Permit_No { get; set; }
        public string Min_No { get; set; }
        public string VatRegTin_F { get; set; }
        public string Accr_No { get; set; }
        public string AccrNo2 { get; set; }
        public string Date { get; set; }
    }
}
