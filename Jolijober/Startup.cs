using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JolijoberProject.Infrastructure.Model.Security;
using JolijoberProject.Infrastructure.MongoDB;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Infrastructure.SqlServer.DataBase;
using JolijoberProject.Main.Repository.Interface;
using JolijoberProject.Main.Repository.Repositores;
using JolijoberProject.Security.Repository.Interfaces;
using JolijoberProject.Security.Repository.Repositores;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Jolijober
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.Configure<JolijoberDatabaseSettings>(
                Configuration.GetSection(nameof(JolijoberDatabaseSettings)));

            services.AddSingleton<IJolijoberDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<JolijoberDatabaseSettings>>().Value);

            services.AddSingleton<JolijoberService>();

            services.AddSingleton<IIdentityRepository, IdentityRepository>();


            services.AddServerSideBlazor();
            services.AddControllersWithViews();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //       .AddCookie(options =>
            //       {
            //           options.LoginPath = "/Account/Login";
            //           options.LogoutPath = "/Account/Login";
            //         });

            services.AddDbContext<JolijoberDbContext>(options =>
           {
               options.EnableSensitiveDataLogging();
               options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
           });

            services.AddIdentity<AccountUser, AccountRole>(identity =>
            {
                //identity.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+!?/|\\[]{}()*$#%^&~";
                //identity.Password.RequiredLength = Convert.ToInt32(Configuration["PasswordLength"]);
               identity.Password.RequireNonAlphanumeric = false;
               identity.Password.RequireLowercase = false;
               identity.Password.RequireUppercase = false;
               identity.Password.RequireDigit = false;
               identity.Password.RequiredUniqueChars = 0;
                ////identity.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(0);
                ////identity.Lockout.MaxFailedAccessAttempts = 5;
                //identity.Lockout.AllowedForNewUsers = false;
            })
          .AddEntityFrameworkStores<JolijoberDbContext>().
          AddDefaultTokenProviders();

            services.AddScoped<IAccountRepository,AccountRepository>();

            //services.AddMvc(options =>
            //{
            //    options.EnableEndpointRouting = false;
            //}).AddRazorPagesOptions(options => {
            //    options.Conventions.AddAreaPageRoute("Identity", "/Account/SignIn", "/Account/SignIn");
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);  // use Latest for Update

            services.AddRazorPages();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Account}/{action=Login}" );
                endpoints.MapBlazorHub();
                 endpoints.MapFallbackToController("Blazor", "Home");
            });
        }
    }
}
