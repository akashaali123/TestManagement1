using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Presenter;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagementCore.Presenter
{
    public class UserPresenter : BasePresenter<UserPresenter>
    {

        private readonly IUser _repository;
        public UserPresenter(IWebHostEnvironment env, IUser repository, ILogger<UserPresenter> logger):base(env,logger)
        {
            _repository = repository;
        }

        public async Task<Object> Login(LoginModel model)
        {
            try
            {
                return await _repository.Login(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in User Login Methode in UserPresenter" + ex);
                return null;

            }
            
        }

        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            try
            {
                return await _repository.PostApplicationUser(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in User PostApplicationUser Methode in UserPresenter" + ex);
                return null;
            }
            
        }



        public async Task<object> CreateRole(RoleModel model)
        {
            try
            {
                return await _repository.CreateRole(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in User CreateRole Methode in UserPresenter" + ex);
                return null;

            }
        }




    }
}
