﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.ViewModel
{
    public class CategoryViewModel
    {
     


        [Required]
        [StringLength(250)]
        public string Name { get; set; }

    }
}
