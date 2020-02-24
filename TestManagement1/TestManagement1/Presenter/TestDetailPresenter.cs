using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.Presenter;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.Presenter
{
    public class TestDetailPresenter : BasePresenter<TestDetailPresenter>
    {

        private readonly ITestDetails _repository;
        public TestDetailPresenter(IWebHostEnvironment env, ITestDetails repository, ILogger<TestDetailPresenter> logger) : base(env, logger)
        {
            _repository = repository;
        }

        public bool Add(TestDetailsViewModel model)
        {
            try
            {
                return _repository.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestDetailPresenter Add Methode in TestDetailPresenter" + ex);

                return false ;

            }
            
        }

    }
}
