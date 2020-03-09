using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.Infrastructure;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.SqlRepository;
using TestManagementCore.Email_Services;
using TestManagementCore.MyTriggerMethode;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.SqlRepository;

namespace TestManagement1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string myAllowSpecificOrigin = "_myAllowSpecificOrigin";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Inject App settings to access appsettingJson Setting to access in controller.... ApplicationSettings class Inject 
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));






            //InjectDbContext
            services.AddDbContext<TestManagementContext>(option =>
           option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //Repository Inject


            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<ICandidate, CandidateRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IExperienceLevel, ExperienceLevelRepository>();
            services.AddScoped<IQuestionAndOption,QuestionAndOptionRepository>();
            services.AddScoped<ITestDetails, TestDetailsRepository>();
            services.AddScoped<ITestResult, TestResultRepository>();
            services.AddScoped<ICompany, CompanyRepository>();
            services.AddScoped<ITestResultByReviewer, TestResultByReviewerRepository>();
            services.AddScoped<IEmailSender,EmailSender>();
            //make for future configuration if we want trigger Like functionality in Future so we use it 
            services.AddScoped<TriggerClass>();

            //services.AddSingleton<TokenProviderDescriptor>();
            //services.AddSingleton<IdentityBuilder>();

        



            //Use Identity
            services.AddIdentity<TblUser, IdentityRole>()
                    .AddEntityFrameworkStores<TestManagementContext>()
                    .AddDefaultTokenProviders();






            services.AddDataProtection();


            //For expiration of token for reset password and Email confirmed
            services.Configure<DataProtectionTokenProviderOptions>(o => 
                                     o.TokenLifespan = TimeSpan.FromMinutes(15)
                                     );


          

            //To remove identity Validation 

            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 6;
                //option.SignIn.RequireConfirmedEmail = true;


            });





                    


           



            //For Cors

            services.AddCors(options =>
            {
                options.AddPolicy(myAllowSpecificOrigin,
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });


            //For Session Create of User id

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
                                                  //services.AddSession();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.  
                options.IdleTimeout = TimeSpan.FromHours(4);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllers().AddNewtonsoftJson();


            //For Jwt
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });


            

            //For Email Services
            var emailConfig = Configuration
                                .GetSection("EmailConfiguration")
                                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // IMPORTANT: This session call MUST go before UseMvc()
             app.UseSession();

            app.UseRouting();

            app.UseCors(myAllowSpecificOrigin);

            
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
