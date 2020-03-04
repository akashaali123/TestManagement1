using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.ViewModel
{
    public class ShuffleQuestionViewModel
    {
        public int questionId { get; set; }

        public string question { get; set; }

        public List<ShuffleOptionViewModel> option { get; set; }
    }
}
