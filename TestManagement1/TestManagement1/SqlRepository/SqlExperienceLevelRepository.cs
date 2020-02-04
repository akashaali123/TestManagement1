using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;

namespace TestManagement1.SqlRepository
{
    public class SqlExperienceLevelRepository : IExperienceLevel
    {
        private readonly TestManagementContext _context;
        private readonly ILogger<SqlExperienceLevelRepository> _logger;

        public SqlExperienceLevelRepository(TestManagementContext context, ILogger<SqlExperienceLevelRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public TblExperienceLevel Add(TblExperienceLevel experienceLevel)
        {
           try
            {
                experienceLevel.IsActive = true;
                experienceLevel.CreatedBy = 1;
                experienceLevel.CreatedDate = DateTime.Now;
                experienceLevel.UpdatedBy = null;
                experienceLevel.UpdatedDate = null;
                _context.TblExperienceLevel.Add(experienceLevel);
                _context.SaveChanges();
                return experienceLevel;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in ExperienceLevel Add Methode in Sql Repository" +ex);
                return null;

            }
        }

        public TblExperienceLevel Delete(int id)
        {
            try
            {
                var experience = _context.TblExperienceLevel.Find(id);
                if (experience != null)
                {
                    _context.TblExperienceLevel.Remove(experience);
                    _context.SaveChanges();
                }
                return experience;
            }
            catch (Exception ex)
            {

               _logger.LogError("Error in ExperienceLevel Delete Methode in Sql Repository" + ex);
                return null;
            }
        }

        public IEnumerable<TblExperienceLevel> GetAll()
        {
            try
            {
                return _context.TblExperienceLevel;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in ExperienceLevel GetAll Methode in Sql Repository" + ex);
                return null;
            }
        }

        public TblExperienceLevel GetExperience(int id)
        {
            try
            {
                return _context.TblExperienceLevel.Find(id);
            }
            catch (Exception ex)
            {

               _logger.LogError("Error in ExperienceLevel GetExperience Methode in Sql Repository" + ex);
                return null;
            }
        }

        public TblExperienceLevel Update(TblExperienceLevel experienceLevel)
        {
            throw new NotImplementedException();
        }
    }
}
