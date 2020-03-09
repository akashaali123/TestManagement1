using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.ViewModel
{
    public class TestQuestionOptionViewModel
    {
        public string Description { get; set; }
       
       // public List<string> option { get; set; }


        public List<string> correctOption { get; set; }


        public List<string> selectOption { get; set; }

    }
}
