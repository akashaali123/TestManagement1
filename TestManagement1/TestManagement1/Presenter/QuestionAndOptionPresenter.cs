using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.Presenter;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.Presenter
{
    public class QuestionAndOptionPresenter: BasePresenter<QuestionAndOptionPresenter>
    {
        private readonly IQuestionAndOption _repository;
        public QuestionAndOptionPresenter(IWebHostEnvironment env, IQuestionAndOption repository, ILogger<QuestionAndOptionPresenter> logger) : base(env, logger)
        {
            _repository = repository;
        }

        public QuestionAndOptionViewModel Add(QuestionAndOptionViewModel model)
        {
            try
            {
                return _repository.Add(model);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionPresenter Add Methode in ExperienceLevelPresenter" + ex);
                return null;
            }
           
        }

        public TblQuestion Delete( int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in QuestionAndOptionPresenter Delete Methode in ExperienceLevelPresenter" + ex);
                return null;

            }

        }

        public QuestionAndOptionViewModel Update(QuestionAndOptionViewModel questionAndOptionViewModel, int id)
        {
            try
            {
                return _repository.Update(questionAndOptionViewModel, id);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionPresenter Update Methode in ExperienceLevelPresenter" + ex);
                return null;
            }
           
        }

        public QuestionOptionByIdViewModel GetQuestionById(int id)
        {
            try
            {
                return _repository.GetQuestionById(id);
            }
            catch (Exception ex)
            {

               _logger.LogError("Error in QuestionAndOptionPresenter GetQuestionById Methode in ExperienceLevelPresenter" + ex);
                return null;
            }
            
        }


        public List<QuestionOptionByIdViewModel> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in QuestionAndOptionPresenter GetAll Methode in ExperienceLevelPresenter" + ex);
                return null;

            }
            
        }
        public List<QuestionOptionByIdViewModel> GetQuestionByCategory(int categoryId)
        {
            try
            {
                return _repository.GetQuestionByCategory(categoryId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionPresenter GetQuestionByCategory Methode in ExperienceLevelPresenter" + ex);
                return null;
            }
           
        }

        public List<QuestionOptionByIdViewModel> GetQuestionByCategoryAndExperience(int categoryId, int experienceLevelId)
        {
            return _repository.GetQuestionByCategoryAndExperience(categoryId, experienceLevelId);
        }

        public List<QuestionOptionByIdViewModel> GetQuestionByCategoryAndExperienceAndNo(int categoryId, int experienceLevelId, int number)
        {
            return _repository.GetQuestionByCategoryAndExperienceAndNo(categoryId, experienceLevelId,number);
        }


    }
}
