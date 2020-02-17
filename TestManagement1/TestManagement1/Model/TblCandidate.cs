using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblCandidate
    {
        public TblCandidate()
        {
            IsActive = true;
        }

        [Key]
        public int CandidateId { get; set; }


        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }



        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        
        public string Email { get; set; }


        [StringLength(250)]
        public string CurrentCompany { get; set; }


        [StringLength(250)]
        public string TechStack { get; set; }

        public bool IsActive { get; set; }

        public int? VacancyId { get; set; }

        public string CreatedBy { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }



    }
}
