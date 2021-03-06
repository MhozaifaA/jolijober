﻿using JolijoberProject.Infrastructure.Model.Security;
using JolijoberProject.Infrastructure.SqlServer.DataBase;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.ExtensionMethod;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Infrastructure.SqlServer.Seed
{
    public static class AccountSeedDB
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var userManager = (UserManager<AccountUser>)services.GetService(typeof(UserManager<AccountUser>));
            var roleManager = (RoleManager<AccountRole>)services.GetService(typeof(RoleManager<AccountRole>));
            var context = (JolijoberDbContext)services.GetService(typeof(JolijoberDbContext));
            
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
               if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new AccountRole() { Name = role });
            }


            var defaultuser = await userManager.FindByNameAsync("Hozaifa");
            if (defaultuser is null)
            {
                AccountUser accountUser = new AccountUser()
                {
                    UserName = "Hozaifa",
                    Email = "Hozaifa".ParsToJolijoberEmail(),
                    AccountType = AccountTypes.User,
                };

                await userManager.CreateAsync(accountUser, "123456");

                await userManager.AddToRoleAsync(accountUser, Roles.User.ToString());
            }


            var defaultcompany = await userManager.FindByNameAsync("jolijober");
            if (defaultcompany is null)
            {
                AccountUser accountUser = new AccountUser()
                {
                    UserName = "jolijober",
                    Email = "jolijober".ParsToJolijoberEmail(),
                    AccountType = AccountTypes.Company,
                };

                 await userManager.CreateAsync(accountUser, "123456");
                 await userManager.AddToRoleAsync(accountUser, Roles.Company.ToString());
            }


        }
    }
}
