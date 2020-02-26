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


        public TestResultViewModel DisplayResultcandidateById(int candidateId)
        {
            try
            {
                return _repository.DisplayResultcandidateById(candidateId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultByReviewer DisplayResultcandidateById Methode in TestResultByReviewerPresenter" + ex);
                return null;
            }
        }




        public List<TestQuestionOptionViewModel> DisplayCandidateQuestion(int candidateId)
        {

            try
            {
                return _repository.DisplayCandidateQuestion(candidateId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultByReviewer DisplayCandidateQuestion Methode in TestResultByReviewerPresenter" + ex);
                return null;
            }


        }


        public List<TestResultViewModel> DisplayResultbyDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyDate(fromDate, toDate);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultByReviewer DisplayResultbyDate Methode in TestResultByReviewerPresenter" + ex);
                return null;
            }
        }

    }
}
