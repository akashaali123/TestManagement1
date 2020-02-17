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

        public int? QuestionId { get; set; }

        public int? SelectedOptionId { get; set; }

        public int? CorrectOptionId { get; set; }

        [DataType(DataType.Time)]
        public DateTime? AttemptedInDuration { get; set; }

        public bool? IsActive { get; set; }

        public string CreatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }


    }
}
