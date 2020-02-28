using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.ViewModel
{
    public class ExperienceLevelViewModel
    {
       

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int? MinExp { get; set; }

        public int? MaxExp { get; set; }
    }
}
