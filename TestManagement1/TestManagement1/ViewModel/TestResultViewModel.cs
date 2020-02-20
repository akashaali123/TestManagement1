using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.ViewModel
{
    public class TestResultViewModel
    {
       

        public int? CandidateId { get; set; }

        public int? CategoryId { get; set; }

        public int? ExpLevelId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? TestDate { get; set; }


        [StringLength(500)]
        public string TestStatus { get; set; }

        public int? TotalQuestion { get; set; }

        public int? AttemptedQuestion { get; set; }

        public float? Percentage { get; set; }

        public int? CorrectAnswer { get; set; }

        public int? WrongAnswer { get; set; }

        public int? QuestionSkipped { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Duration { get; set; }

        public bool? IsActive { get; set; }

       
    }
}
