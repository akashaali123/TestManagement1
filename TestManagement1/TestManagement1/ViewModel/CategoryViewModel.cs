using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }


        [Required]
        [StringLength(250)]
        public string Name { get; set; }

    }
}
