using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;

namespace TestManagement1.Presenter
{
    public class CategoryPresenter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICategory _repository;
        private readonly ILogger<CategoryPresenter> _logger;
        public CategoryPresenter(IWebHostEnvironment env, ICategory repository, ILogger<CategoryPresenter> logger)
        {
            _env = env;
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<TblCategory> GetAllCategory()
        {
            try
            {
                return _repository.GetAllCategory();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in Category GetAllCategory Methode in CategoryPresenter" +ex);
                 return null;
            }
        }

        public TblCategory Add(TblCategory category)
        {
            try
            {
                return (_repository.Add(category));
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in Category Add Methode in CategoryPresenter" + ex);
                return null;
            }
        }


        public TblCategory Delete(int id)
        {
            try
            {
                return (_repository.Delete(id));
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in Category Delete Methode in CategoryPresenter" + ex);
                return null;
            }
        }



    }
}
