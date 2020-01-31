using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblSessionHistory
    {
        public TblSessionHistory()
        {
            IsActive = true;
        }

        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? SessionId { get; set; }

        public bool IsActive { get; set; }

        [StringLength(250)]
        public string Jwt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
    }
}
