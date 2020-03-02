using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.ViewModel;

namespace TestManagement1.RepositoryInterface
{
    public interface ICategory
    {
        TblCategory GetCategory(int id);

        IEnumerable<TblCategory> GetAllCategory();

        TblCategory Add(CategoryViewModel category);

        public TblCategory Update(CategoryViewModel categoryModel,
                                  int id);

        public bool Delete(int id);
    }
}
