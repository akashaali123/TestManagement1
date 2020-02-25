using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagementCore.ViewModel;

namespace TestManagementCore.RepositoryInterface
{
    public interface ITestResultByReviewer
    {
        public List<TestResultViewModel> DisplayResultAllCandidate();
    }
}
