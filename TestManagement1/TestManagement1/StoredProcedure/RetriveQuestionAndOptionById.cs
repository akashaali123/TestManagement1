using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.StoredProcedure
{
    public class RetriveQuestionAndOptionById
    {

        //For Sp

        [Key]
        
        public int QuestionId { get; set; }
        

        
        public string OptionDescription { get; set; }

       
        public bool IsCorrect { get; set; }
    }
}
