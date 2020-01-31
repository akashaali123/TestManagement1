using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblOption
    {
        public TblOption()
        {
            IsActive = true;
        }
        [Key]
        public int OptionId { get; set; }


        [Required]
        [StringLength(500)]
        public string OptionDescription { get; set; }

        public bool? IsCorrect { get; set; }

        public int? QuestionId { get; set; }


        [DataType(DataType.Time)]
        public DateTime? Duration { get; set; }


        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }
    }
}
