using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.SqlRepository;

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
            services.AddScoped<IUser, SqlUser>();
            services.AddScoped<ICandidateRepository, SqlCandidateRepository>();
            services.AddScoped<ICategory, SqlCategoryRepository>();
            services.AddScoped<IExperienceLevel, SqlExperienceLevelRepository>();






            //Use Identity
            services.AddIdentity<TblUser, IdentityRole>()
                    .AddEntityFrameworkStores<TestManagementContext>();


            //add scoped for user Repository
            
            //services.AddTransient<IUser, SqlUser>();
            //services.AddSingleton<IUser, SqlUser>();


            services.AddControllers();


            //To remove identity Validation 

            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 4;

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


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
