using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    [Table("HeaderFooter_VQPBOS")]
    public class HeaderFooterVQP
    {
        [Key]
        public int Id { get; set; }
        public int BranchCode { get; set; }
        public int StoreCode { get; set; }
        public string Type { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Zip_Location { get; set; }
        public string Zip_Code { get; set; }
        public string VatRegTin_H { get; set; }
        public string PosNo { get; set; }
        public string PermitNo { get; set; }
        public string SerialNo { get; set; }
        public string MinNo { get; set; }
        public string VatRegTin_F { get; set; }
        public string AccrNo { get; set; }
        public string AccrNo2 { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
}
