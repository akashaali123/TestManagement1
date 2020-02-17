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
            return _repository.Update(questionAndOptionViewModel, id);
        }

    }
}
