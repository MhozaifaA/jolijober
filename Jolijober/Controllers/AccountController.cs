using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        public async Task<IActionResult> Signin()
        {
            await Task.CompletedTask;
            return View();
        }
       
    }
}
