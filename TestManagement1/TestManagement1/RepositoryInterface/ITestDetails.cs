﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagementCore.ViewModel;

namespace TestManagementCore.RepositoryInterface
{
    public interface ITestDetails
    {
        public bool Add(TestDetailsViewModel model);

    }
}
