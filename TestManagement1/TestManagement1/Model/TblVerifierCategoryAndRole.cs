using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.Model
{
    public class TblVerifierCategoryAndRole
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string UserId { get; set; }

        [StringLength(500)]
        public string CategoryId { get; set; }

        [StringLength(500)]
        public string RoleId { get; set; }
    }
}
