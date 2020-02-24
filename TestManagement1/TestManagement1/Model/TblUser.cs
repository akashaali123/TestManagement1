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
        
        public string JwtToken { get; set; }


        public int? RoleId { get; set; }


        public bool IsActive { get; set; }


        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }



    }
}
