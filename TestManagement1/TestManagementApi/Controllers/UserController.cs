using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;
using TestManagementCore.Presenter;
using TestManagementCore.ViewModel;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController :BaseController<UserPresenter>
    {
        // private readonly IUser _userRepository; //User Repository Object
        UserPresenter userPresenter;

        public UserController(IWebHostEnvironment webHostEnvironment, IUser repository, ILogger<UserPresenter> logger) : base(webHostEnvironment, logger)
        {
            userPresenter = new UserPresenter(webHostEnvironment, repository, logger);

        }







        #region UserRegistration
        [HttpPost]
        [Route("/user/register")]
        //POST : api/User/Register
        public async Task<IActionResult> PostApplicationUser(ApplicationUserModel model)
        {
            

            var user = await userPresenter.PostApplicationUser(model);
            return helperMethode(user, "user");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion






        #region UserLogIn
        [HttpPost]
        [Route("/user/login")]
        //POST : api/User/Login
        public async Task<IActionResult> Login(LoginModel model)
        {

            

            var jwtToken = await userPresenter.Login(model);
            return helperMethode(jwtToken, "jwttoken");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion











        #region CreateRole
        [HttpPost]
        [Route("/user/createrole")]
        //POST : api/User/createrole
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            
            var role = await userPresenter.CreateRole(model);
            return helperMethode(role, "role");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion







        #region Edit role in User
        [HttpPost]
        [Route("/user/edituserinrole")]
        public async Task<IActionResult> EditUserInRole(UserRoleViewModel model, string roleId)
        {
           

            var editUserInRole = await userPresenter.EditUserInRole(model, roleId);
            return helperMethode(editUserInRole, "editUserInRole");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }


        #endregion





        #region Getall
        [HttpGet]
        [Route("/user/getall")]
        public IActionResult Getall()
        {
            
            var user = userPresenter.UserList();
            return helperMethode(user, "users");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller



        }
        #endregion








        #region DeleteUser
        [HttpDelete]
        [Route("/user/delete")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            
            var deleteUser = await userPresenter.DeleteUser(id);
            return helperMethode(deleteUser, "user");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion






        #region GetUserById
        [HttpGet]
        [Route("/user/getbyid")]
        public async Task<IActionResult> GetUserById(string id)
        {
           
            var getUser = await userPresenter.GetUserById(id);
            return helperMethode(getUser, "user");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller


        }
        #endregion








        #region Update
        [HttpPut]
        [Route("/user/update")]
        public async Task<IActionResult> Update(UserViewModelById model, string id)
        {
            
            var updateUser = await userPresenter.UpdateUser(model, id);
            return helperMethode(updateUser, "user");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller


        }
        #endregion






        #region ChangePassword
        [HttpPost]
        [Route("/user/changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model, string id)
        {
           
            var password = await userPresenter.ChangePassword(model, id);
            return helperMethode(password, "password");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller


        }
        #endregion









    }
}