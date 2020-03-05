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

        public TestResultPresenter(IWebHostEnvironment env,
                                   ITestResult repository,
                                   ILogger<TestResultPresenter> logger) : base(env, logger)
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
        public List<TestResultViewModel> DisplayResultbyDate(DateTime fromDate,
                                                             DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyDate(fromDate,
                                                       toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyDate Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultbyPercentage()
        {
            try
            {
                return _repository.DisplayResultbyPercentage();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyPercentage Methode in CategoryPresenter" + ex);
                return null;

            }
            
        }


        public List<TestResultViewModel> DisplayResultbyPercentageAndCategory(int categoryId)
        {
            try
            {
                return _repository.DisplayResultbyPercentageAndCategory(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyPercentageAndCategory Methode in CategoryPresenter" + ex);
                return null;

            }
           
        }

        public List<TestResultViewModel> DisplayResultbyPercentageAndCategoryAndExperience(int categoryId,
                                                                                           int experienceLevelId)
        {
            try
            {
                return _repository.DisplayResultbyPercentageAndCategoryAndExperience(categoryId,
                                                                                     experienceLevelId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyPercentageAndCategoryAndExperience Methode in CategoryPresenter" + ex);
                return null;

            }
            
        }

        public List<TestResultViewModel> DisplayResultbyPercentageAndExperience(int experienceId)
        {
            try
            {
                return _repository.DisplayResultbyPercentageAndExperience(experienceId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyPercentageAndExperience Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }

        public List<TestResultViewModel> DisplayResultbyCategory(int categoryId)
        {
            try
            {
                return _repository.DisplayResultbyCategory(categoryId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyCategory Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }
        public List<TestResultViewModel> DisplayResultbyExperience(int experienceId)
        {
            try
            {
                return _repository.DisplayResultbyExperience(experienceId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyExperience Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }
        public List<TestResultViewModel> DisplayResultbyCategoryAndExperience(int categoryId,
                                                                              int experienceId)
        {
            try
            {
                return _repository.DisplayResultbyCategoryAndExperience(categoryId,
                                                                        experienceId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyCategoryAndExperience Methode in CategoryPresenter" + ex);
                return null;

            }
            
        }
        public List<TestResultViewModel> DisplayResultbyCategoryFromDate(int categoryId,
                                                                         DateTime fromDate,
                                                                         DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyCategoryFromDate(categoryId,
                                                                   fromDate,
                                                                   toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyCategoryFromDate Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultbyExpFromDate(int experienceId,
                                                                    DateTime fromDate,
                                                                    DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyExpFromDate(experienceId,
                                                              fromDate,
                                                              toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyExpFromDate Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }

        public List<TestResultViewModel> DisplayResultbyCatAndExpFromDate(int categoryId,
                                                                          int experienceId,
                                                                          DateTime fromDate,
                                                                          DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyCatAndExpFromDate(categoryId,
                                                                    experienceId,
                                                                    fromDate,
                                                                    toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyCatAndExpFromDate Methode in CategoryPresenter" + ex);
                return null;

            }
            
        }

        public List<TestResultViewModel> DisplayResultbyTestStatus(string status)
        {
            try
            {
                return _repository.DisplayResultbyTestStatus(status);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTestStatus Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultbyTestStatusAndCat(string status,
                                                                         int categoryId)
        {
            try
            {
                return _repository.DisplayResultbyTestStatusAndCat(status,
                                                                   categoryId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyTestStatusAndCat Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultbyTestStatusAndExp(string status,
                                                                         int experienceId)
        {
            try
            {
                return _repository.DisplayResultbyTestStatusAndExp(status, 
                                                                   experienceId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTestStatusAndExp Methode in CategoryPresenter" + ex);
                return null;

            }
           
        }
        public List<TestResultViewModel> DisplayResultbyTestStatusAndExpAndCat(string status,
                                                                               int experienceId,
                                                                               int categoryId)
        {
            try
            {
                return _repository.DisplayResultbyTestStatusAndExpAndCat(status,
                                                                         experienceId,
                                                                         categoryId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyTestStatusAndExp Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }

        public List<TestResultViewModel> DisplayResultbyTestStatusFromDate(string status,
                                                                           DateTime fromDate,
                                                                           DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyTestStatusFromDate(status,
                                                                     fromDate,
                                                                     toDate);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyTestStatusAndExp Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }

        public List<TestResultViewModel> DisplayResultbyTestStatusandCatFromDate(string status,
                                                                                 int categoryId,
                                                                                 DateTime fromDate,
                                                                                 DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyTestStatusandCatFromDate(status,
                                                                           categoryId,
                                                                           fromDate,
                                                                           toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTestStatusandCatFromDate Methode in CategoryPresenter" + ex);
                return null;

            }
            
        }

        public List<TestResultViewModel> DisplayResultbyTestStatusandCatAndExpFromDate(string status,
                                                                                       int categoryId,
                                                                                       int experienceId,
                                                                                       DateTime fromDate,
                                                                                       DateTime toDate)
        {
            try
            {
                return _repository.DisplayResultbyTestStatusandCatAndExpFromDate(status,
                                                                                 categoryId,
                                                                                 experienceId,
                                                                                 fromDate,
                                                                                 toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTestStatusandCatAndExpFromDate Methode in CategoryPresenter" + ex);
                return null;
            }
          
        }

        public List<TestResultViewModel> DisplayResultbyTop10Percentage()
        {
            try
            {
                return _repository.DisplayResultbyTop10Percentage();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10Percentage Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndCategory(int categoryId)
        {
            try
            {
                return _repository.DisplayResultbyTop10PercentageAndCategory(categoryId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10PercentageAndCategory Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndCategoryAndExperience(int categoryId,
                                                                                                int experienceLevelId)
        {
            try
            {
                return _repository.DisplayResultbyTop10PercentageAndCategoryAndExperience(categoryId,
                                                                                          experienceLevelId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10PercentageAndCategoryAndExperience Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndExperience(int experienceId)
        {
            try
            {
                return _repository.DisplayResultbyTop10PercentageAndExperience(experienceId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10PercentageAndExperience Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultbyTop10TestStatus(string status)
        {
            try
            {
                return _repository.DisplayResultbyTop10TestStatus(status);
            }
            catch (Exception ex)
            { 
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10TestStatus Methode in CategoryPresenter" + ex);
                return null;
            }
           
        }

        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndCat(string status,
                                                                              int categoryId)
        {
            try
            {
                return _repository.DisplayResultbyTop10TestStatusAndCat(status, 
                                                                        categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10TestStatusAndCat Methode in CategoryPresenter" + ex);
                return null;

            }
           
        }

        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndExp(string status,
                                                                              int experienceId)
        {
            try
            {
                return _repository.DisplayResultbyTop10TestStatusAndExp(status, 
                                                                        experienceId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10TestStatusAndExp Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }
        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndExpAndCat(string status,
                                                                                    int experienceId,
                                                                                    int categoryId)
        {
            try
            {
                return _repository.DisplayResultbyTop10TestStatusAndExpAndCat(status,
                                                                              experienceId,
                                                                              categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultPresenter DisplayResultbyTop10TestStatusAndExpAndCat Methode in CategoryPresenter" + ex);
                return null;
            }
            
        }

        public int TestCount()
        {
            try
            {
                return _repository.TestCount();

            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter TestCount Methode in CategoryPresenter" + ex);
                return 0;
            }
        }

        public int PasscandidateCount()
        {
            try
            {
                return _repository.PasscandidateCount();

            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter PasscandidateCount Methode in CategoryPresenter" + ex);
                return 0;
            }
        }


        public int FailcandidateCount()
        {
            try
            {
                return _repository.FailcandidateCount();

            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultPresenter FailcandidateCount Methode in CategoryPresenter" + ex);
                return 0;
            }
        }



    }
}
