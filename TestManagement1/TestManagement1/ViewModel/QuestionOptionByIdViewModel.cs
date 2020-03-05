using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;

namespace TestManagementCore.ViewModel
{
    public class QuestionOptionByIdViewModel
    {


        // public TblQuestion question { get; set; }



        //public List<TblOption> option { get; set; } 

        public int questionId { get; set; }
        public string question { get; set; }

        public int? categoryId { get; set; }

        public int? experienceLevelId { get; set; }

        public int? time { get; set; }

        
        //public int optionId { get; set; }
        // public List<string> option { get; set; }

        public List<OptionViewModel> option { get; set; }



    }
}
