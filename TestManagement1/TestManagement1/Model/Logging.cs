using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblLogging
    {
        [Key]
        public int Id { get; set; }

        public string Application { get; set; }

        public string Logged { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public string Logger { get; set; }

        public string CallSite { get; set; }

        public string Exception { get; set; }

        public string FilePath { get; set; }

    }
}
