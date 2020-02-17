using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagementCore.ViewModel;

namespace TestManagementCore.RepositoryInterface
{
    public interface IQuestionAndOption
    {
        QuestionAndOptionViewModel Add(QuestionAndOptionViewModel model);

        IEnumerable<QuestionAndOptionViewModel> GetAll();

        TblQuestion Delete(int id);

        QuestionAndOptionViewModel Update(QuestionAndOptionViewModel questionAndOptionViewModel,int id);

    }
}
