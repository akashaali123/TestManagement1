using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.ViewModel
{
    public class QuestionOptionByIdViewModel
    {

        //For question
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

       
     
        public string option { get; set; }

        
        



    }
}
