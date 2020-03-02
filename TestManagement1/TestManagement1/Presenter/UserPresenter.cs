using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.Presenter;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;
using TestManagementCore.ViewModel;

namespace TestManagementCore.Presenter
{
    public class UserPresenter : BasePresenter<UserPresenter>
    {

        private readonly IUser _repository;
        public UserPresenter(IWebHostEnvironment env,
                             IUser repository,
                             ILogger<UserPresenter> logger):base(env,logger)
        {
            _repository = repository;
        }

        public async Task<object> Login(LoginModel model)
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


        public async Task<object> EditUserInRole(UserRoleViewModel model, 
                                                 string roleId)
        {
            try
            {
                return await _repository.EditUserInRole(model,
                                                        roleId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in User EditUserInRole Methode in UserPresenter" + ex);
                return null;

            }
           
        }
        public List<UserListViewModel> UserList()
        {
            try
            {
                return _repository.UserList();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User UserList Methode in UserPresenter" + ex);
                return null;
            }
           
        }

        public async Task<object> DeleteUser(string id)
        {
            try
            {
                return await _repository.DeleteUser(id);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User DeleteUser Methode in UserPresenter" + ex);
                return null;
            }
           

        }

        public async Task<object> GetUserById(string id)
        {
            try
            {
                return await _repository.GetUserById(id);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User GetUserById Methode in UserPresenter" + ex);
                return null;
            }
            
        }

        public async Task<object> UpdateUser(UserViewModelById model, 
                                             string id)
        {
            try
            {
                return await _repository.UpdateUser(model, 
                                                    id);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User UpdateUser Methode in UserPresenter" + ex);
                return null;
            }
            
        }

        public async Task<object> ChangePassword(ChangePasswordViewModel model,
                                                 string id)
        {
            try
            {
                return await _repository.ChangePassword(model,
                                                        id);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User ChangePassword Methode in UserPresenter" + ex);
                return null;
            }
            
        }

        public async Task<bool> Logout()
        {
            try
            {
                return await _repository.Logout();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in User Logout Methode in UserPresenter" + ex);
                return false;

            }
        }


        public List<RoleViewModel> ListRole()
        {
            try
            {
                return _repository.ListRole();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User ListRole Methode in UserPresenter" + ex);
                return null;
            }
          
        }

        public async Task<object> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                return await _repository.ForgotPassword(model);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User ForgotPassword Methode in UserPresenter" + ex);
                return null;
            }
           
        }

        public async Task<object> ResetPassword(ResestPasswordViewModel model)
        {
            try
            {
                return await _repository.ResetPassword(model);
            }
            catch (Exception ex)
            {


                _logger.LogError("Error in User ResetPassword Methode in UserPresenter" + ex);
                return null;
            }
           
        }

        public async Task<object> ConfirmEmail(string email, 
                                               string token)
        {
            try
            {
                return await _repository.ConfirmEmail(email,
                                                      token);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in User ConfirmEmail Methode in UserPresenter" + ex);
                return null;
            }
            
        }



    }
}
