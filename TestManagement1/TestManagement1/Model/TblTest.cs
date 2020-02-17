using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblTest
    {
        public TblTest()
        {
            IsActive = true;
        }
        [Key]
        public int TestId { get; set; }

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

        public string CreatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }
    }
}
