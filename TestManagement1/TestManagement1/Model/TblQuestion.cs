using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblQuestion
    {
        public TblQuestion()
        {
            IsActive = true;
        }
        [Key]
        public int QuestionId { get; set; }


        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public string Type { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public int? Marks { get; set; }

        public bool? IsActive { get; set; }

        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }

        public int? CategoryId { get; set; }

        public int? ExperienceLevelId { get; set; }

        public string Roleid { get; set; }

    }
}
