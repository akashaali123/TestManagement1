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
    public class ExperienceLevelPresenter
    {
        private readonly IWebHostEnvironment _env;

        private readonly IExperienceLevel _repository;

        private readonly ILogger<ExperienceLevelPresenter> _logger;
        public ExperienceLevelPresenter(IWebHostEnvironment env, IExperienceLevel repository, ILogger<ExperienceLevelPresenter> logger)
        {
            _env = env;
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<TblExperienceLevel> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ExperienceLevel GetAll Methode in ExperienceLevelPresenter" + ex);
                return null;
            }
        }

        public TblExperienceLevel Add(TblExperienceLevel experienceLevel)
        {
            try
            {
                return _repository.Add(experienceLevel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ExperienceLevel Add Methode in ExperienceLevelPresenter" + ex);
                return null;

            }
        }

        public TblExperienceLevel Delete(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in ExperienceLevel Delete Methode in ExperienceLevelPresenter" + ex);
                return null;
            }
        }

    
    
    }
}
