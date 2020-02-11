using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository; //User Repository Object

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository; //Inject User Repository

        }







        #region UserRegistration
        [HttpPost]
        [Route("/user/register")]
        //POST : api/User/Register
        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var user = await _userRepository.PostApplicationUser(model);

                if (user != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("user", user);

                    // Return Data 
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "User Created",
                        data
                    });
                }
                else
                {
                    // Error Returned
                    return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status400BadRequest,
                        message = "Invalid Attempt",
                        data
                    });

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
                return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status502BadGateway,
                        message = "Exception Found",
                        data
                    });
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
                var jwtToken = await _userRepository.Login(model);


                if (jwtToken != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("jwtToken", jwtToken);

                    // Return Data
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "User Logged In Succcesfully",
                        data
                    });
                }
                else
                {
                    // Error Returned
                    return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status400BadRequest,
                        message = "Invalid User Name or Password",
                        data
                    });

                }
            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception
                return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status502BadGateway,
                        message = "Exception Found",
                        data
                    });
            }
            // Function Ended
        }
        #endregion








        #region CreateRole
        [HttpPost]
        [Route("/user/createrole")]
        //POST : api/User/createrole
        public async Task<object> CreateRole(RoleModel model)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();


                var role = await _userRepository.CreateRole(model);
                if (role != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("role", role);

                    // Return Data
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "Role Created",
                        data
                    });

                }
                else
                {
                    // Error Returned
                    return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status400BadRequest,
                        message = "Invalid Attempt",
                        data
                    });
                }
            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception
                return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status502BadGateway,
                        message = "Exception Found",
                        data
                    });
            }
            // Function Ended     
        }
        #endregion












    }
}