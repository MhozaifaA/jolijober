using Jolijober.ViewModel;
using JolijoberProject.Security.Repository.DataTransferObjects;
using JolijoberProject.Security.Repository.Interfaces;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.ExtensionMethod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountRepository AccountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
           _httpContextAccessor = httpContextAccessor;
            AccountRepository = accountRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)//SignIn
        {
            // in Layout  use Base "/" for blazor soo in returnUrl Ignor "/"
            ViewBag.returnUrl = returnUrl == "/" ? null : returnUrl;
            ViewData["Translate"] = Request.Cookies["Translate"];
            return View();
        }


     

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel signIn, string returnUrl)
        {

            //read cookie from IHttpContextAccessor  
            //string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["Keylang-hzo"];

          //  Set("Translate", "ar", 30*60*24);

            ////read cookie from Request object  
            ///
            ViewData["Translate"] = Request.Cookies["Translate"];

            bool IsEn= Request.Cookies["Translate"] == "en";

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(String.Empty, IsEn? "please fill required fields" : "الرجاء ملئ الحقول");
                return View(signIn);
            }

            var result = await AccountRepository.SignInAsync(new LoginDto()
            {
                Password = signIn.Password,
                Username = signIn.UserName,
                RememberMe = signIn.RememberMe,
            });

            if (result is null)
            {
                ModelState.AddModelError(String.Empty, IsEn?"username or password not currect": "اسم المستخدم أو كلمة المرور غير صحيحة");
                return View(signIn);
            }
            if (String.IsNullOrEmpty(returnUrl == "/" ? null : returnUrl))
                return result.AccountType==AccountTypes.User?Redirect("/Index"): Redirect("/Company"); // id
            else return Redirect(returnUrl ?? "/");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(SignUpViewModel signUp, AccountTypes account)
        {
            if (!TryValidateModel(signUp))
            {
                ViewData[$"SignUpErorr{account}"] = signUp.ErrorMessage;
                return View(nameof(Login));
            }

            var result = await AccountRepository.SignUpAsync(new CreateAccountDto()
            {
                AccountType = account,
                Country = signUp.Country,
                Password = signUp.Passward,
                UserName = signUp.UserName,
                FullName= signUp.FullName
            });

            if (result.IsFaild)
            {
                ViewData[$"SignUpErorr{account}"] = result.TextFaild;
            }

            return View(nameof(Login));
        }


        //Aoth
        public async Task<IActionResult> LogoutAsync(string id)//SignIn
        {
            if (!await AccountRepository.SignOutAsync())
            {
                return View(nameof(Login));
            }
            return RedirectToAction(nameof(Login));
        }


        [HttpGet("/Translate/{lang}")]
        [AllowAnonymous]
        public  IActionResult Translate([FromRoute]string lang)
        {
            //read cookie from IHttpContextAccessor  
           // string Translate = _httpContextAccessor.HttpContext.Request.Cookies["Translate"];
            Set("Translate", lang, 30*60*24);
            ViewData["Translate"] = Request.Cookies["Translate"];
            return RedirectToAction("Login");
        }

        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }

    }
}
