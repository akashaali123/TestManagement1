using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblCategory
    {
        public TblCategory()
        {
            IsActive = true;
        }
        [Key]
        public int CategoryId { get; set; }


        [Required]
        [StringLength(250)]
        public string Name { get; set; }


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
