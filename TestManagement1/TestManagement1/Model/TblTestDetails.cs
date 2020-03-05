using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblTestDetails
    {
        public TblTestDetails()
        {
            IsActive = true;
        }

        [Key]
        public int TestId { get; set; }

        public int CandidateId { get; set; }
        public int? QuestionId { get; set; }

        [StringLength(250)]
        public string SelectedOptionId { get; set; }

        [StringLength(250)]
        public string CorrectOptionId { get; set; }

        
        public int? AttemptedInDuration { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        public string UpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }


    }
}
