using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblUserRole
    {
        [Key]
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public int? UserId { get; set; }
    }
}
