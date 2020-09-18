using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Jolijober.Util.Translate;
using JolijoberProject.Hub.SignalR.Repositories;
using JolijoberProject.Infrastructure.Model.Security;
using JolijoberProject.Infrastructure.MongoDB;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Infrastructure.SqlServer.DataBase;
using JolijoberProject.Main.Repository.Interfaces;
using JolijoberProject.Main.Repository.Repositories;
using JolijoberProject.Security.Repository.Interfaces;
using JolijoberProject.Security.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Tewr.Blazor.FileReader;

namespace Jolijober
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;

        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDistributedMemoryCache();

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});

            services.Configure<JolijoberDatabaseSettings>(
                Configuration.GetSection(nameof(JolijoberDatabaseSettings)));

            services.AddSingleton<IJolijoberDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<JolijoberDatabaseSettings>>().Value);

            services.AddSingleton<JolijoberService>();

            services.AddSingleton<IIdentityRepository, IdentityRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();

            services.AddResponseCompression();
            services.AddServerSideBlazor().AddCircuitOptions(o =>
             {
                 if (_env.IsDevelopment()) //only add details when debugging
                 {
                     o.DetailedErrors = true;
                 }
             });

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

            services.AddScoped<IAccountRepository, AccountRepository>();

            //services.AddMvc(options =>
            //{
            //    options.EnableEndpointRouting = false;
            //}).AddRazorPagesOptions(options => {
            //    options.Conventions.AddAreaPageRoute("Identity", "/Account/SignIn", "/Account/SignIn");
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);  // use Latest for Update




            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
            });

            // GDPR
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddRazorPages();

            services.AddFileReaderService();
            //.AddHubOptions(o =>
            // {
            //     o.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
            // });

            services.AddHttpContextAccessor();
               services.AddTransient<AppTranslate>();
            //  services.AddTransient<IAppTranslate,AppTranslate>();

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
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}");
                endpoints.MapBlazorHub();
                endpoints.MapHub<JolijoberHub>("/JolijoberHub/Notify");
                endpoints.MapFallbackToController("Blazor", "Home");
               // endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
