using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;
using TestManagementCore.Email_Services;
using TestManagementCore.Presenter;
using TestManagementCore.SessionManager;
using TestManagementCore.ViewModel;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController :BaseController<UserPresenter>
    {
        // private readonly IUser _userRepository; //User Repository Object
        UserPresenter userPresenter;

        private readonly IEmailSender _emailSender;

        private readonly ApplicationSettings _appSettings;//For Jwt


        public UserController(IWebHostEnvironment webHostEnvironment,
                              IUser repository,
                              ILogger<UserPresenter> logger,
                              IEmailSender emailSender,
                               IOptions<ApplicationSettings> appSettings) : base(webHostEnvironment, logger)
        {
            userPresenter = new UserPresenter(webHostEnvironment, repository, logger);

            _emailSender = emailSender;

            _appSettings = appSettings.Value;//For jwt

        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        #region UserRegistration
        [HttpPost]
        [Route("/user/register")]
        //POST : api/User/Register
        public async Task<IActionResult> PostApplicationUser(ApplicationUserModel model)
        {
            

            var user = await userPresenter.PostApplicationUser(model);

            //For confirmation Account Via Email
            if (user != null)
            {
               //generate url with token and send to the user
                var callback = Url.Action("ConfirmEmail", "User", new { email = model.email, token = user }, Request.Scheme);

                var message = new Message(new string[] { model.email }, "Account Confirmation link", "Account Confirmation Link " + callback);
                _emailSender.SendEmail(message);

            }


            return helperMethode(user, "user");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion


        //when user register their account it generate the url for confirm email
        //whe he hit url this api is call and account is confirm
        [HttpGet]
        [Route("/user/confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string email,
                                                      string token)
        {
            var confirmEmail = await userPresenter.ConfirmEmail(email,
                                                                token);

            return helperMethode(confirmEmail, "confirmemail");
        }








        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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








        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>


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






        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        #region Edit role in User
        [HttpPost]
        [Route("/user/edituserinrole")]
        public async Task<IActionResult> EditUserInRole(UserRoleViewModel model,
                                                        string roleId)
        {
           

            var editUserInRole = await userPresenter.EditUserInRole(model,
                                                                    roleId);
            return helperMethode(editUserInRole, "editUserInRole");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }


        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

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







        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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






        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        #region Update
        [HttpPut]
        [Route("/user/update")]
        public async Task<IActionResult> Update(UserViewModelById model,
                                                string id)
        {
            
            var updateUser = await userPresenter.UpdateUser(model,
                                                            id);
            return helperMethode(updateUser, "user");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller


        }
        #endregion




        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        #region ChangePassword
        [HttpPost]
        [Route("/user/changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model,
                                                        string id)
        {
           
            var password = await userPresenter.ChangePassword(model,
                                                              id);
            return helperMethode(password, "password");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion

       
        
        
        
        
        [HttpPost]
        [Route("/user/logout")]
        public async Task<IActionResult> LogOut()
        {
            var logout = await userPresenter.Logout();
            return helperMethode(logout, "logout");
        }


        //[HttpGet]
        //[Route("/user/session")]
        //public IActionResult GetSession()
        //{
        //    return Ok(sessionManager.getSession("userid"));




        //}

        [HttpGet]
        [Route("/user/rolelist")]
        public IActionResult ListRole()
        {
            var role = userPresenter.ListRole();
            return helperMethode(role, "roles");
        }


        [HttpPost]
        [Route("/user/forgotpassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            var token = await userPresenter.ForgotPassword(model);
            if (token != null)
            {
                //Generate url with token for reset password send the user email
               // var callback = Url.Action("ResetPassword","User", new { email = model.Email, token =  HttpUtility.UrlEncode(token.ToString()) }, Request.Scheme);


                
                // var url = string.Format("{0}{1}?email={2}&token={3}",Request.Scheme,_appSettings.ResetPassword_URL, model.Email,HttpUtility.UrlEncode(token.ToString()));
                

                var url = string.Format("{0}{1}?email={2}&token={3}", Request.Scheme, _appSettings.ResetPassword_URL, model.Email, HttpUtility.UrlEncode(token.ToString()));

                var message = new Message(new string[] {model.Email }, "ResetPasswordlink", "Reset password token " + url);
                _emailSender.SendEmail(message);

            }

            return helperMethode(token, "token");
        }



        //when user click the url form is open having two field password and confirm password
        //we get password these two fields and token,email get by their url and post the request 
        
        [HttpPost]
        [Route("/resetpassword")]
        public async Task<IActionResult> ResetPassword(string email , 
                                                        string token,
                                                        PasswordModelBinding modelBinding)
        {

            //string tt = "CfDJ8OKmzg4eTYhBq9Oj3yQfTgqs7HrR+RggfmxEbS4OsHz8MD3UVqiKBQN80oabvZjcSe4SO5sZSdp+J5qjAyHv2UA4hH+Hh1cL4zReK7x67DtG4D3yfsNUef3zNJZwpMvyOWH3lTdH5L4zmC/x+zVKlFs/lrk4ax6sbjJEiRtObhvejinBmEBb5Pac0yA6JTRqDgnY+krf6yrWvG3nVgJn2PVyJaBmD6UbicHYdAkZ/HHi";
            string decode = HttpUtility.UrlDecode(token);
            decode = decode.Replace(" ", "+");

            var model = new ResestPasswordViewModel 
                                { 
                                    Email = email,
                                    Token = decode,
                                    Password = modelBinding.Password,
                                    ConfirmPassword = modelBinding.ConfirmPassword 
                                };

            var resetPasswordEmail = await userPresenter.ResetPassword(model);

            return helperMethode(resetPasswordEmail, "resetpasswordemail");
        }


        [HttpGet]
        [Route("/user/noofuser")]
        public IActionResult NoOfUser()
        {
            int count = userPresenter.NoOfUser();
            return helperMethode(count, "count");
        }



    }
}
