using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagement1.Presenter
{
    public class ExperienceLevelPresenter :BasePresenter<ExperienceLevelPresenter>
    {
       

        private readonly IExperienceLevel _repository;

       
        public ExperienceLevelPresenter(IWebHostEnvironment env, IExperienceLevel repository, ILogger<ExperienceLevelPresenter> logger):base(env,logger)
        {
           
            _repository = repository;
            
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

        public TblExperienceLevel Add(ExperienceLevelViewModel experienceLevel)
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
