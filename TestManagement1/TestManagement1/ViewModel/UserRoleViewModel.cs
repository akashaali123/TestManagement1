using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestManagementCore.ViewModel
{
    public class UserRoleViewModel
    {
        public string userId { get; set; }

        public string userName { get; set; }

        public bool isSelected { get; set; }

    }

   
}
