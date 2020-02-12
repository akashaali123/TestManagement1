using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblUser:IdentityUser
    {
        [StringLength(2000)]
        public string JwtToken { get; set; }


        public int? RoleId { get; set; }


        public bool IsActive { get; set; }


        public int? CreatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }



    }
}
