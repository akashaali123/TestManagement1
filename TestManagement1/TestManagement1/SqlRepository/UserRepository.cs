﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestManagement1.ViewModel;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;

namespace TestManagement1.SqlRepository
{
    public class UserRepository : IUser
    {
        private UserManager<TblUser> _userManager;

        private SignInManager<TblUser> _signInManager;

        private readonly ApplicationSettings _appSettings;

        private readonly RoleManager<IdentityRole> _roleManager;


        
        public UserRepository(UserManager<TblUser> userManager, SignInManager<TblUser> signInManager, IOptions<ApplicationSettings> appSettings, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _appSettings = appSettings.Value;
            
            _roleManager = roleManager;

        }
       
       


        
        
        public async Task<Object> Login(LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.userName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("userId", user.Id.ToString()) //We access this userID in UserProfile Controller
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(5),

                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);

                    var token = tokenHandler.WriteToken(securityToken);


                    user.JwtToken = token; //take Jwt value in db for temporary
                    await _userManager.UpdateAsync(user);

                    return token;
                }
                else
                {
                    return null;
                    
                }
            }
            catch (Exception ex)
            {
                return new { message = "Exception found in User repository (Will change it later) : " + ex };
            }
           
        }

        
        
        
       
        
        
        public async Task<IActionResult> Logout()
        {
           throw  new NotImplementedException();
        }

       
        
        
        
       
        
        
        
        
        
        
        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            try
            {
                var applicationUser = new TblUser()
                {

                UserName = model.userName, //the value pass to the model and we assign the model value in application user constructor to take a value in database

                Email = model.email,
                

                IsActive = true,

                JwtToken = null,

                CreatedDate = System.DateTime.Now

                };

           
                var result = await _userManager.CreateAsync(applicationUser, model.password); //password assign here

                return result; //return object of new user               
            }
            catch (Exception ex)
            {

                return new { message = "Exception found in User repository PostApplication (Will change it later) : " + ex };
            }
        }







        public async Task<object> CreateRole(RoleModel model)
        {

            try
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.roleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return result;
                }
                return model;
            }
            catch(Exception ex)
            {
                return new { message = "Exception found in User repository CreateRole (Will change it later) : " + ex };
            }
           
        }    
  
    
    
    
    
    
    }
}
