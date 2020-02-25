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
        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public string RoleId { get; set; }
    }
}
