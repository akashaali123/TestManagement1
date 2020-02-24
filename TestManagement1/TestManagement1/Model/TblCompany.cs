using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.Model
{
    public class TblCompany
    {
        [Key]
        public int CompanyId { get; set; }
        
        [StringLength(1000)]
        public string CompanyName { get; set; }
    }
}
