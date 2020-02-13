using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.ViewModel;
using TestManagementCore.ViewModel;

namespace TestManagement1.RepositoryInterface
{
    public interface IUser
    {
        public Task<object> PostApplicationUser(ApplicationUserModel model);

        public Task<object> Login(LoginModel model);


        public Task<IActionResult> Logout();


        public Task<object> CreateRole(RoleModel model);

        public Task<object> EditUserInRole(UserRoleViewModel model, string roleId);

    }
}
