using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    public class DBSettings
    {
        [Key]
        public int Id { get; set; }

        public string DBName { get; set; }

        public string EJSourcePath { get; set; }

        public string EJOutputPath { get; set; }


        public int? CompanyCode { get; set; }

        public int? BranchCode { get; set; }

        public string Description { get; set; }
        public string DataSource { get; set; }

        public string InitialCatalog { get; set; }

        public string UserID { get; set; }

        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public bool isActive { get; set; }

    }
}
