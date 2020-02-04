using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;

namespace TestManagement1.RepositoryInterface
{
    public interface ICategory
    {
        TblCategory GetCategory(int id);

        IEnumerable<TblCategory> GetAllCategory();

        TblCategory Add(TblCategory category);

        TblCategory Update(TblCategory category);

        TblCategory Delete(int id);
    }
}
