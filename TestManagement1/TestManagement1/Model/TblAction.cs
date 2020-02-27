using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.Model
{
    public class TblAction
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string RoleId { get; set; }

        public string Actionperform { get; set; }

        public string TableName { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime ActionDate { get; set; }
    }
}
