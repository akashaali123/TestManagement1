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
    public class TestDetailsRepository : BaseRepository<TestDetailsRepository>, ITestDetails
    {
        public TestDetailsRepository(TestManagementContext context, ILogger<TestDetailsRepository> logger, IHttpContextAccessor httpContextAccessor):base(context, logger, httpContextAccessor)
        {

        }
        public TblTestDetails Add(TestDetailsViewModel model)
        {
            var correctoption = _context.TblOption.Where(e => e.QuestionId == model.QuestionId && e.IsCorrect == true).SingleOrDefault();

            TblTestDetails testDetails = new TblTestDetails
            {
                TestId = model.TestId,
                CandidateId = model.Candidateid,
                QuestionId = model.QuestionId,
                SelectedOptionId =model.SelectedOptionId,
                CorrectOptionId = correctoption.OptionId,
                AttemptedInDuration = model.AttemptedInDuration,
                IsActive = model.IsActive
                
            };

            _context.TblTestDetails.Add(testDetails);
            _context.SaveChanges();
            return testDetails;

        }
    }
}
