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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? TestDate { get; set; }


        [StringLength(500)]
        public string TestStatus { get; set; }

        public int? TotalQuestion { get; set; }

        public int? AttemptedQuestion { get; set; }

        public double? Percentage { get; set; }

        public int? CorrectAnswer { get; set; }

        public int? WrongAnswer { get; set; }

        public int? QuestionSkipped { get; set; }

        
        public string Duration { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        public string UpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }


        public string TotalTimeForTest { get; set; }
    }
}
