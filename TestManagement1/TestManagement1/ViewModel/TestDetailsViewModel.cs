using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.ViewModel
{
    public class TestDetailsViewModel
    {
        [Key]
        public int TestId { get; set; }

        public int Candidateid { get; set; }
        public int? QuestionId { get; set; }

        public string SelectedOptionId { get; set; }

        //public int[] CorrectOptionId { get; set; }

        [DataType(DataType.Time)]
        public DateTime? AttemptedInDuration { get; set; }

        public bool? IsActive { get; set; }

        
    }
}
