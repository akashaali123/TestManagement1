using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagementCore.Model;

namespace TestManagementCore.RepositoryInterface
{
    public interface ICompany
    {

        public IEnumerable<TblCompany> GetAllCompany();
    }
}
