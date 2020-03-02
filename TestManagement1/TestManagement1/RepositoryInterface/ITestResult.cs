using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagementCore.ViewModel;

namespace TestManagementCore.RepositoryInterface
{
    public interface ITestResult
    {
        public Dictionary<string, bool> AddResult(int candidateId);

        public List<TestResultViewModel> DisplayResultAllCandidate();

        public TestResultViewModel DisplayResultcandidateById(int candidateId);

        public List<TestResultViewModel> DisplayResultbyDate(DateTime fromDate,
                                                             DateTime toDate);
        
        public List<TestResultViewModel> DisplayResultbyPercentage();

        public List<TestResultViewModel> DisplayResultbyPercentageAndCategory(int categoryId);

        public List<TestResultViewModel> DisplayResultbyPercentageAndCategoryAndExperience(int categoryId,
                                                                                           int experienceLevelId);

        public List<TestResultViewModel> DisplayResultbyPercentageAndExperience(int experienceId);
       
        public List<TestResultViewModel> DisplayResultbyCategory(int categoryId);
        
        public List<TestResultViewModel> DisplayResultbyExperience(int experienceId);
        
        public List<TestResultViewModel> DisplayResultbyCategoryAndExperience(int categoryId,
                                                                              int experienceId);

        public List<TestResultViewModel> DisplayResultbyCategoryFromDate(int categoryId,
                                                                         DateTime fromDate,
                                                                         DateTime toDate);

        public List<TestResultViewModel> DisplayResultbyExpFromDate(int experienceId,
                                                                    DateTime fromDate,
                                                                    DateTime toDate);
        
        public List<TestResultViewModel> DisplayResultbyCatAndExpFromDate(int categoryId,
                                                                          int experienceId,
                                                                          DateTime fromDate,
                                                                          DateTime toDate);

        public List<TestResultViewModel> DisplayResultbyTestStatus(string status);

        public List<TestResultViewModel> DisplayResultbyTestStatusAndCat(string status,
                                                                         int categoryId);

        public List<TestResultViewModel> DisplayResultbyTestStatusAndExp(string status,
                                                                         int experienceId);

        public List<TestResultViewModel> DisplayResultbyTestStatusAndExpAndCat(string status,
                                                                               int experienceId,
                                                                               int categoryId);

        public List<TestResultViewModel> DisplayResultbyTestStatusFromDate(string status,
                                                                           DateTime fromDate,
                                                                           DateTime toDate);
        
        public List<TestResultViewModel> DisplayResultbyTestStatusandCatFromDate(string status,
                                                                                 int categoryId,
                                                                                 DateTime fromDate,
                                                                                 DateTime toDate);
        
        public List<TestResultViewModel> DisplayResultbyTestStatusandCatAndExpFromDate(string status,
                                                                                       int categoryId,
                                                                                       int experienceId,
                                                                                       DateTime fromDate,
                                                                                       DateTime toDate);
        
        public List<TestResultViewModel> DisplayResultbyTop10Percentage();

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndCategory(int categoryId);

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndCategoryAndExperience(int categoryId,
                                                                                                int experienceLevelId);

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndExperience(int experienceId);

        public List<TestResultViewModel> DisplayResultbyTop10TestStatus(string status);

        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndCat(string status,
                                                                              int categoryId);

        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndExp(string status,
                                                                              int experienceId);

        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndExpAndCat(string status,
                                                                                    int experienceId,
                                                                                    int categoryId);




    }
}
