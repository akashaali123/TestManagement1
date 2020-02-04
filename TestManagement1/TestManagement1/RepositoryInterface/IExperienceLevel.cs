using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;

namespace TestManagement1.RepositoryInterface
{
    public interface IExperienceLevel
    {
        TblExperienceLevel GetExperience(int id);
        IEnumerable<TblExperienceLevel> GetAll();

        TblExperienceLevel Add(TblExperienceLevel experienceLevel);

        TblExperienceLevel Update(TblExperienceLevel experienceLevel);

        TblExperienceLevel Delete(int id);
    }
}
