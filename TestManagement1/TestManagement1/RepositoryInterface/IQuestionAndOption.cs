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

        public List<QuestionOptionByIdViewModel> GetAll();

        TblQuestion Delete(int id);

        QuestionAndOptionViewModel Update(QuestionAndOptionViewModel questionAndOptionViewModel,int id);

        

        public QuestionOptionByIdViewModel GetQuestionById(int id);

        public List<QuestionOptionByIdViewModel> GetQuestionByCategory(int categoryId);

        public List<QuestionOptionByIdViewModel> GetQuestionByCategoryAndExperience(int categoryId, int experienceLevelId);

        public List<QuestionOptionByIdViewModel> GetQuestionByCategoryAndExperienceAndNo(int categoryId, int experienceLevelId, int number);


        public List<QuestionOptionByIdViewModel> GetQuestionByCategoryAndExperienceAndNumberAndShuffling(int candidateId, int number);

        public List<QuestionOptionByIdViewModel> GetAllByRole();

    }
}
