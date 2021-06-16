using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Business.Abstract;
using StudentPortal.Business.Concrete;
using StudentPortal.Business.Containers;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.DataAccess.Concrete.EntityFramework;
using StudentPortal.WebUI.Identity;
using StudentPortal.WebUI.Middlewares;

namespace StudentPortal.WebUI
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDependencies();
            services.AddControllers();
            services.AddSession();
            services.AddControllersWithViews();

            services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer("server=VEDAT; Database=PortalDb; Trusted_Connection=true; MultipleActiveResultSets=true"));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();



            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoöprsþtuüvyzABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ0123456789-._";

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath= "/Account/Login";
                options.LogoutPath= "/Admin/Logout";
                options.AccessDeniedPath = "/Admin/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Portal.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            app.UseDeveloperExceptionPage();
            
            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "Teacher",
                    pattern: "teacher/{controller=Home}/{action=Index}/{id?}"
                );


                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "Student",
                    pattern: "student/{controller=Home}/{action=Index}/{id?}"
                );

               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });

            SeedIdentity.Seed(userManager, roleManager, config).Wait();
        }
    }
}
