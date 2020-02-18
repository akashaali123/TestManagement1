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
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                
                var user = await userPresenter.PostApplicationUser(model);
                if (user != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("user", user);
                   
                    // Return Data 
                    //MyReturnMethode Return the data in Ok result its implementation in base Controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "User Created", data);

                }
                else
                {
                    // Error Returned

                    //MyReturnMethode Return the data in Ok result its implementation in base Controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                   

                }
                // Clear
            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex); 

                // Return Exception


                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);

              
            }
            // Function Ended
        }
        #endregion






        #region UserLogIn
        [HttpPost]
        [Route("/user/login")]
        //POST : api/User/Login
        public async Task<IActionResult> Login(LoginModel model)
        {

            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                // calling JWT token from user Model
                
                var jwtToken = await userPresenter.Login(model);

                if (jwtToken != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("jwtToken", jwtToken);


                    //create Session

                   //HttpContext.Session.SetString("User", "True");
                   // var user = HttpContext.Session.GetString("User");

                    // Return Data

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "User Logged In Succcesfully", data);

                   
                }
                else
                {
                    // Error Returned

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid User Name or Password", data);

                    

                }
            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception

                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);

               
            }
            // Function Ended
        }
        #endregion








      
        
        
        #region CreateRole
        [HttpPost]
        [Route("/user/createrole")]
        //POST : api/User/createrole
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();


               
                var role = await userPresenter.CreateRole(model);
                if (role != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("role", role);

                    // Return Data

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "Role Created", data);                
                }
                else
                {
                    // Error Returned

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);

                }
            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception

                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
               
            }
            // Function Ended     
        }
        #endregion



       
        
        
        
        #region Edit role in User
        [HttpPost]
        [Route("/user/edituserinrole")]
        public async Task<IActionResult> EditUserInRole(UserRoleViewModel model, string roleId)
        {
            try
            {
              
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();
                
                var editUserInRole = await userPresenter.EditUserInRole(model, roleId);

                if (editUserInRole!=null)
                {
                    data.Add("Edit User In Role", editUserInRole);

                    return MyReturnMethode(true, StatusCodes.Status200OK, "Assigned Role to User SuccessFully", data);
                }
                else
                {
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                }

            }
            catch (Exception ex)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("exception", ex);
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }
        }


        #endregion





        #region Getall
        [HttpGet]
        [Route("/user/getall")]
        public IActionResult Getall()
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var user = userPresenter.UserList();

                if (user != null)
                {
                    data.Add("userList", user);

                    return MyReturnMethode(true, StatusCodes.Status200OK, "User List", data);
                }
                else
                {
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                }
            }
            catch (Exception ex)
            {

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("exception", ex);
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }



        }
        #endregion








        #region DeleteUser
        [HttpDelete]
        [Route("/user/delete")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                var deleteUser = await userPresenter.DeleteUser(id);
                if (deleteUser != null)
                {
                    data.Add("DeleteUser", deleteUser);

                    return MyReturnMethode(true, StatusCodes.Status200OK, "User List", data);

                }
                else
                {
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                }

            }
            catch (Exception ex)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("exception", ex);
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);

            }

        }
        #endregion






        #region GetUserById
        [HttpGet]
        [Route("/user/getbyid")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                var getUser = await userPresenter.GetUserById(id);
                if (getUser != null)
                {
                    data.Add("User By ID", getUser);

                    return MyReturnMethode(true, StatusCodes.Status200OK, "User List", data);
                }
                else
                {
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                }

            }
            catch (Exception ex)
            {

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("exception", ex);
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }


        }
        #endregion








        #region Update
        [HttpPut]
        [Route("/user/update")]
        public async Task<IActionResult> Update(UserViewModelById model, string id)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                var updateUser = await userPresenter.UpdateUser(model, id);
                if (updateUser != null)
                {
                    data.Add("updated User", updateUser);

                    return MyReturnMethode(true, StatusCodes.Status200OK, "User List", data);
                }
                else
                {
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                }

            }
            catch (Exception ex)
            {

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("exception", ex);
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }


        }
        #endregion






        #region ChangePassword
        [HttpPost]
        [Route("/user/changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model, string id)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                var password = await userPresenter.ChangePassword(model, id);
                if (password != null)
                {
                    data.Add("change Password", password);

                    return MyReturnMethode(true, StatusCodes.Status200OK, "User List", data);
                }
                else
                {
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                }
            }
            catch (Exception ex)
            {

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("exception", ex);
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }


        }
        #endregion









    }
}