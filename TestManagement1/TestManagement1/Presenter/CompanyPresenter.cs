using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Presenter;
using TestManagementCore.Model;
using TestManagementCore.RepositoryInterface;

namespace TestManagementCore.Presenter
{
    public class CompanyPresenter : BasePresenter<CompanyPresenter>
    {

        private readonly ICompany _repository;
        public CompanyPresenter(IWebHostEnvironment env,
                                ICompany repository,
                                ILogger<CompanyPresenter> logger) : base(env, logger)
        {
            _repository = repository;

        }
        public IEnumerable<TblCompany> GetAllCompany()
        {
            try
            {
                return _repository.GetAllCompany();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in CompanyPresenter GetAllCompany Methde in Presenter" + ex);
                return null;
            }
           
        }
    }
}
