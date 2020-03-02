using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.ViewModel;

namespace TestManagement1.RepositoryInterface
{
    public interface IExperienceLevel
    {
        TblExperienceLevel GetExperience(int id);
        IEnumerable<TblExperienceLevel> GetAll();

        TblExperienceLevel Add(ExperienceLevelViewModel experienceLevel);

        public TblExperienceLevel Update(ExperienceLevelViewModel experienceLevelModel,
                                         int id);

        bool Delete(int id);
    }
}
