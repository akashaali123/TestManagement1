using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.SqlRepository;
using TestManagement1.ViewModel;



namespace TestManagement1.Controllers
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



        [HttpPost]

        [Route("Register")]

        //POST : api/User/Register

        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            var data = await _userRepository.PostApplicationUser(model);
            int status = StatusCodes.Status201Created;
            bool success = true;
            return Ok(new { success, status, message = "Success", data });
        }

        

        [HttpPost]

        [Route("Login")]

        //POST : api/User/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var jwtToken = await _userRepository.Login(model);
            
           
            int status = StatusCodes.Status200OK;
            bool success = true;
            return Ok(new { success, status, message = "Success",  jwtToken });

           
        }



      
        
        
        [HttpPost]
        [Route("createrole")]
        //POST : api/User/createrole
        public async Task<object> CreateRole(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var data = await _userRepository.CreateRole(model);
               
                int status = StatusCodes.Status201Created;
                bool success = true;
                return Ok(new { success, status, message = "Success", data });
            }
            else
            {
                return BadRequest();
            }
           
        }


    }
}