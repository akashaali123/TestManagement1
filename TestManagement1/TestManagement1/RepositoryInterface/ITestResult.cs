﻿using System;
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

        public List<TestResultViewModel> DisplayResultbyDate(DateTime fromDate, DateTime toDate);

    }
}
