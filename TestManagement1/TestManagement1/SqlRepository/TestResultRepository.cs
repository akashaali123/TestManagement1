using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.SqlRepository;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.SqlRepository
{
    public class TestResultRepository : BaseRepository<TestResultRepository>, ITestResult
    {
        public TestResultRepository(TestManagementContext context, ILogger<TestResultRepository> logger, IHttpContextAccessor httpContextAccessor) :base(context, logger, httpContextAccessor)
        {

        }

        public string AddResult(int candidateId)
        {
            //TestResultViewModel model = new

            //TblTest test = new TblTest
            //{
            //    CandidateId = model.CandidateId,
            //    CategoryId = model.CategoryId,
            //    ExpLevelId = model.ExpLevelId,
            //    TestDate = model.TestDate,
            //    TestStatus = model.TestStatus,
            //    TotalQuestion = model.TotalQuestion,
            //    AttemptedQuestion = model.AttemptedQuestion,
            //    Percentage = model.Percentage,
            //    CorrectAnswer = model.CorrectAnswer,
            //    WrongAnswer = model.WrongAnswer,
            //    QuestionSkipped = model.QuestionSkipped,
            //    Duration = model.Duration,
            //    IsActive = model.IsActive

            //};

            var data = _context.TblTestDetails.Where(e => e.CandidateId == candidateId).Select(x => new {x.QuestionId,x.SelectedOptionId,x.CorrectOptionId });


            return "null";
        }



    }
}
