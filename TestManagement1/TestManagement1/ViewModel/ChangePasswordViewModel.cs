using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string oldpassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string newpassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("newpassword",ErrorMessage ="New Password and Confirmation Password do not match")]
        public string confirmpassword { get; set; }
    }
}
