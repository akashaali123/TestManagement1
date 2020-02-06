using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestManagement1.BindingModel;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.SqlRepository;

namespace TestManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IUser _userRepository; //User Repository Object

        public ApplicationUserController(IUser userRepository)
        {
            _userRepository = userRepository; //Inject User Repository

        }



        [HttpPost]

        [Route("Register")]

        //POST : api/ApplicationUser/Register

        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            var result = await _userRepository.PostApplicationUser(model);
            return Ok(result);
        }



        [HttpPost]

        [Route("Login")]

        //POST : api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _userRepository.Login(model);

            return Ok(new { result });
        }



      
        
        
        [HttpPost]
        [Route("createrole")]
        //POST : api/ApplicationUser/createrole
        public async Task<object> RoleCreate(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userRepository.RoleCreate(model);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
           
        }


    }
}