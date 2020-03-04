using Microsoft.AspNetCore.Identity;
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
using TestManagementCore.ViewModel;
using System.Text.Json;
using System.Collections;
using Microsoft.AspNetCore.Http;
using TestManagementCore.SessionManager;
using TestManagementCore.Model;
using TestManagementCore.Email_Services;
using System.Web;

namespace TestManagement1.SqlRepository
{
    public class UserRepository : IUser
    {
        private UserManager<TblUser> _userManager;

        private SignInManager<TblUser> _signInManager;

        private readonly ApplicationSettings _appSettings;

        private readonly RoleManager<IdentityRole> _roleManager;

        SessionManager sessionManager;

       private readonly TestManagementContext _context;


        protected readonly IHttpContextAccessor _httpContextAccessor;




        //For Session
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;


        public UserRepository(UserManager<TblUser> userManager,
                              SignInManager<TblUser> signInManager,
                              IOptions<ApplicationSettings> appSettings,
                              RoleManager<IdentityRole> roleManager,
                              IHttpContextAccessor httpContextAccessor,
                              TestManagementContext context)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _appSettings = appSettings.Value;
            
            _roleManager = roleManager;

           
             sessionManager =   new SessionManager(httpContextAccessor);
            _context = context;

            _httpContextAccessor = httpContextAccessor;

           
        }
       
       


        
        
        public async Task<object> Login(LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.userName);


                ////Get the Role of signing User save in it a list
                var userRole = await _userManager.GetRolesAsync(user);

                var role = await _roleManager.FindByNameAsync(userRole[0]);

                //Find the role Info by thier name which hold in userRole 0 index
                // IdentityRole  roleInfo = await _roleManager.FindByNameAsync(userRole[0]);


                if (user != null && await _userManager.CheckPasswordAsync(user, model.password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("userid", user.Id.ToString()),//We access this userID in UserProfile Controller
                        new Claim("email", user.Email.ToString()),
                        new Claim("role",  role.Name.ToString()),
                        new Claim("roleid",  role.Id.ToString()),
                        new Claim("username",user.UserName.ToString()),
                        new Claim("isactive",user.IsActive.ToString()),
                        //new Claim(ClaimTypes.Role,roles.ToString())
                        
                        }),
                        
                        Expires = DateTime.UtcNow.AddHours(5),

                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);

                    var token = tokenHandler.WriteToken(securityToken);

                    
                    user.JwtToken = token; //take Jwt value in db for temporary
                    var result = await _userManager.UpdateAsync(user);
                    
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







        public async Task<bool> Logout()
        {
            try
            {
                
                var user = await _userManager.FindByIdAsync(GetUserId());
                
                user.JwtToken = null;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
                
            }
            
        }

       
        
        
        
       
        
        
        
        
        
        
        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            try
            {




                var applicationUser = new TblUser()
                {

                    UserName = model.userName, //the value pass to the model and we assign the model value in application user constructor to take a value in database

                    Email = model.email,

                    RoleId = model.roleId,

                    //CategoryId = model.categoryId.ToString(),
                    // CategoryId = model.categoryId,

                    IsActive = true,

                    JwtToken = null,

                    CreatedDate = System.DateTime.Now,

                    CreatedBy = GetUserId()

                     

                };

           
                var result = await _userManager.CreateAsync(applicationUser, model.password); //password assign here
               
                if(result.Succeeded)
                {
                    //when account create SuccessFully its genarate the token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);

                    
                    //Find Role
                    var role = await _roleManager.FindByIdAsync(model.roleId);
                    if (role == null)
                    {
                        return new { message = "No Role Found" };
                    }
                    else
                    {
                        if (role.Name == "verifier")
                        {
                            
                            
                            IdentityResult identityResult = null;
                            
                            identityResult = await _userManager.AddToRoleAsync(applicationUser, role.Name);

                            //If role verifier assigned to User
                            if (identityResult.Succeeded) 
                            {
                                //We map it TblVerifierCategoryAndRole
                                TblVerifierCategoryAndRole map = new TblVerifierCategoryAndRole
                                {
                                    UserId = applicationUser.Id,
                                    CategoryId = model.categoryId,
                                    RoleId = role.Id
                                };
                                _context.TblVerifierCategoryAndRole.Add(map);
                                _context.SaveChanges();
                                
                                return token; //return Token For Email Confirmation
                            }
                            else
                            {
                                return new { message = "Error in Assigning Role" };
                            }
                            

                           

                        }
                        else
                        {
                           //if role is other than verifier

                            IdentityResult identityResult = null;
                            
                            identityResult = await _userManager.AddToRoleAsync(applicationUser, role.Name);
                            return token; //return Token For Email Confirmation
                        }

                        
                    }                      
                       
                }
                else
                {
                    return new { message = "Problem in User Creation" };
                }

                //return result; //return object of new user               
            }
            catch (Exception ex)
            {

                return new { message = "Exception found in User repository PostApplication  " + ex };
            }
        }




        //If confirmation Email send to the user and it hit the url so this function is called
        public async Task<object> ConfirmEmail(string email,
                                               string token)
        {
            //take email and token from the url which we send to the user
            try
            {
                if (email == null || token == null)
                {
                    return new { message = "Invalid Token Or Email" };
                }

                //Find user by their url mail
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return new { message = "Invalid Email" };
                }

                //confirm mail 
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    return new { message = "Email Confirmed Successfully" };
                }

                return new { message = "Email can not be Confirmed" };
            }
            catch (Exception ex)
            {
                return new { message = "Exception found in User repository ConfirmEmail  " + ex };

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

      
        
        
        public async Task<object> EditUserInRole(UserRoleViewModel model, 
                                                 string roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null )
                {
                    return new { message = "No Role Found" };
                }
                else
                {
                    IdentityResult result = null;
                    var user = await _userManager.FindByIdAsync(model.userId);
                    result = await _userManager.AddToRoleAsync(user, role.Name);


                    return new { message = "Role is Assigned", data = new {role , model } };
                }
            }
            catch (Exception ex)
            {

                return new { message = "Exception found in User repository EditUserInRole  (Will change it later) : " + ex };
            }
               

            #region check it later
            //    for (int i = 0; i < model.Count; i++)
            //    {
            //        var user = await _userManager.FindByIdAsync(model[i].userId);
            //        IdentityResult result = null;
            //        if (model[i].isSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
            //        {
            //            result = await _userManager.AddToRoleAsync(user, role.Name);
            //        }
            //        else if (!model[i].isSelected && await _userManager.IsInRoleAsync(user, role.Name))
            //        {
            //            result = await _userManager.RemoveFromRoleAsync(user, role.Name);
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //        if (result.Succeeded)
            //        {
            //            if (i < (model.Count - 1))
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                return new { id = roleId };
            //            }
            //        }
            //    }
            //    return new { id = roleId };
            //}
            //catch (Exception ex)
            //{

            //    return new { message = "Exception found in User repository EditUserInRole  (Will change it later) : " + ex };
            //}
            #endregion


        }

        public List<UserListViewModel> UserList()
        {
            try
            {
                
                var allusers =  _context.Users.ToList();
                var userVM = allusers.Select(user => new UserListViewModel { id = user.Id, userName = user.UserName, email = user.Email }).ToList();
                return userVM;
            }
            catch (Exception)
            {
                return null;

            }
            


        }

        public async Task<object> GetUserById(string id)
        {
            try
            {
                UserViewModelById userList = new UserViewModelById();
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return new { message = "No Result Found" };
                }
                else
                {
                    userList.userName = user.UserName;
                    userList.email = user.Email;
                    return userList;
                }
            }
            catch (Exception ex)
            {

                return new { message = "Exception found in User repository GetUserById (Will change it later) : " + ex };
            }
           

        }


        public async Task<object> DeleteUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return new { message = "Not Found" };
                }
                else
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return result;
                    }
                    else
                    {
                        return new { message = "Some Error Occurs" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new { message = "Exception found in User repository DeleteUser  (Will change it later) : " + ex };

            }
           
               
            
        }

        public async Task<object> UpdateUser(UserViewModelById model,
                                             string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.UserName = model.userName;
                    user.Email = model.email;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return model;
                    }
                    else
                    {
                        return new { message = "Error Occured" };
                    }


                }
                else
                {
                    return new { message = "No Result Found" };
                }
            }
            catch (Exception ex)
            {

                return new { message = "Exception found in User repository UpdateUser  (Will change it later) : " + ex };
            }
           

        }


        public async Task<object> ChangePassword(ChangePasswordViewModel model,
                                                 string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.oldpassword, model.newpassword);
                    if (result.Succeeded)
                    {
                        await _signInManager.RefreshSignInAsync(user);
                        return result;
                    }
                    else
                    {
                        return new { message = "In Correct Old Password" };
                    }
                }
                else
                {
                    return new { message = "No User Found" };
                }
            }
            catch (Exception ex)
            {
                return new { message = "Exception found in User repository ChangePassword  (Will change it later) : " + ex };

            }
           

        }

        public  List<RoleViewModel> ListRole()
        {
            try
            {
                var vmList = new List<RoleViewModel>();
                var role = _context.Roles.Select(e => new { e.Id, e.Name }).ToList();

                foreach (var item in role)
                {
                    RoleViewModel model = new RoleViewModel();
                    model.Id = item.Id;
                    model.name = item.Name;
                    vmList.Add(model);
                }
                return vmList;
            }
            catch (Exception)
            {

                return null;

            }
          
        }


        //when user enter its mail through forget password
        public async Task<object> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                //find user by their mail
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    //generate token for reset password
                      var token = await _userManager.GeneratePasswordResetTokenAsync(user); //set LifeTime span for email and password differently

                    //var token = await _userManager.CreateSecurityTokenAsync(user);
                    //user.token = token.ToString();
                    //await _userManager.UpdateAsync(user);

                    return token;

                }
                else
                {
                    return new {message = "Invalid Email" };
                }
            }
            catch (Exception ex)
            {

                return new { message = "Exception found in User repository ForgotPassword   " + ex };
            }
           
        }


        //If reset password send to the user and it hit the url so this function is called
        //open new page where two field set password and confirm password
        public async Task<object> ResetPassword(ResestPasswordViewModel model)
        {
            try
            {
                //Find user by mail and mail get through the url
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                     //await _userManager.RemovePasswordAsync(user);


                    //set  reset password
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                       // var   result = await _userManager.AddPasswordAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return new { message = "Reset Password Successfully" };
                    }
                    else
                    {
                        return new { message = "Invalid Token" };
                    }



                }
                else
                {
                    return new { message = "Invalid Email" };
                }
            }
            catch (Exception ex)
            {

                return new { message = "Exception found in User repository ResetPassword   " + ex };
            }
           
        
        }



        public int NoOfUser()
        {
            try
            {

                var noOfUser =  _context.Users.Count();

                return noOfUser;
                
            }
            catch (Exception)
            {

                return 0;
            }


        }





        //To find the current login user id which is used in created by
        public string GetUserId()
        {
            string userId = _httpContextAccessor.HttpContext
                                                .User
                                                .Claims.
                                                FirstOrDefault(c => c.Type == "userid")
                                                .Value;
            return userId;
        }



    }
}
