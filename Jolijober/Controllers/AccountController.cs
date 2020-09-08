using Jolijober.ViewModel;
using JolijoberProject.Security.Repository.DataTransferObjects;
using JolijoberProject.Security.Repository.Interfaces;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.ExtensionMethod;
using Microsoft.AspNetCore.Authorization;
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
        private IAccountRepository AccountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            AccountRepository = accountRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)//SignIn
        {
            // in Layout  use Base "/" for blazor soo in returnUrl Ignor "/"
            ViewBag.returnUrl = returnUrl == "/" ? null : returnUrl;
         
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel signIn, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
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
                ModelState.AddModelError(String.Empty, "username or password not currect");
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
                UserName = signUp.UserName
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

    }
}
