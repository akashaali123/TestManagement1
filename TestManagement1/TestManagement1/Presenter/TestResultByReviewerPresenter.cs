using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Presenter;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.Presenter
{
    public class TestResultByReviewerPresenter : BasePresenter<TestResultByReviewerPresenter>
    {

        ITestResultByReviewer _repository;
        public TestResultByReviewerPresenter(IWebHostEnvironment env, ITestResultByReviewer repository, ILogger<TestResultByReviewerPresenter> logger) : base(env, logger)
        {
            _repository = repository;
        }


        public List<TestResultViewModel> DisplayResultAllCandidate()
        {
            try
            {
                return _repository.DisplayResultAllCandidate();
            }
            catch (Exception ex)
            {


                _logger.LogError("Error in TestResultByReviewer DisplayResultAllCandidate Methode in TestResultByReviewerPresenter" + ex);
                return null;
            }
            
        }



    }
}
