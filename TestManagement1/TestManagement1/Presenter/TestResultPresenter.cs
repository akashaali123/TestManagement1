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
    public class TestResultPresenter : BasePresenter<TestResultPresenter>
    {

        private readonly ITestResult _repository;

        public TestResultPresenter(IWebHostEnvironment env, ITestResult repository, ILogger<TestResultPresenter> logger) : base(env, logger)
        {
            _repository = repository;
        }

        public Dictionary<string, bool> AddResult(int candidateId)
        {
            try
            {
                return _repository.AddResult(candidateId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter AddResult Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultAllCandidate()
        {
            try
            {
                return _repository.DisplayResultAllCandidate();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultAllCandidate Methode in CategoryPresenter" + ex);
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
                _logger.LogError("Error in TestResultPresenter DisplayResultcandidateById Methode in CategoryPresenter" + ex);
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
                _logger.LogError("Error in TestResultPresenter DisplayResultbyDate Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }
    }
}
