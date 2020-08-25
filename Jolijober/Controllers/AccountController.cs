﻿using Jolijober.ViewModel;
using JolijoberProject.Security.Repository.DataTransferObjects;
using JolijoberProject.Security.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository AccountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            AccountRepository = accountRepository;
        }

        public IActionResult SignIn(string returnUrl)
        {
            // in Layout  use Base "/" for blazor soo in returnUrl Ignor "/"
            ViewBag.returnUrl = returnUrl == "/" ? null : returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signIn, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(signIn);
            }

            var result= await   AccountRepository.SignInAsync(new LoginDto() {
                 Password= signIn.Password,
                 Username= signIn.UserName,
                 RememberMe=signIn.RememberMe,
              } );

            if (result is null)
            {
                ModelState.AddModelError(String.Empty, "username or password not currect");
                return View(signIn);
            }
            if (String.IsNullOrEmpty(returnUrl == "/" ? null : returnUrl))
                return Redirect("/Home/Index");
            else return Redirect(returnUrl ?? "/");
        }

        public async Task<IActionResult> SignUp()
        {
            await Task.CompletedTask;
            return View();
        }

    }
}
