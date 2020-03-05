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
        
        public string Description { get; set; }


        [StringLength(250)]
        public string Type { get; set; }


        public int? Time { get; set; }

        public int? Marks { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [StringLength(500)]
        public string UpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }

        public int? CategoryId { get; set; }

        public int? ExperienceLevelId { get; set; }

        [StringLength(500)]
        public string Roleid { get; set; }

    }
}
