using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblExperienceLevel
    {
        public TblExperienceLevel()
        {
            IsActive = true;
        }
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int? MinExp { get; set; }

        public int? MaxExp { get; set; }

        public bool? IsActive { get; set; }

        public string CreatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }

    }
}
