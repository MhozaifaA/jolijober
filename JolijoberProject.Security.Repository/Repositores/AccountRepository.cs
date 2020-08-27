using JolijoberProject.Base.Context.SqlServer;
using JolijoberProject.Infrastructure.Model.Security;
using JolijoberProject.Infrastructure.SqlServer.DataBase;
using JolijoberProject.Security.Repository.DataTransferObjects;
using JolijoberProject.Security.Repository.Interfaces;
using JolijoberProject.Shared.SharedKernal.ExtensionMethod;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Security.Repository.Repositores
{
    public class AccountRepository : JolijoberRepository,IAccountRepository
    {
        #region -   Constructor   -

        public UserManager<AccountUser> UserManager { get; }
        public SignInManager<AccountUser> SignInManager { get; }
        private RoleManager<AccountRole> RoleManager { get; }

        public AccountRepository(JolijoberDbContext context, UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager, RoleManager<AccountRole> roleManager) : base(context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }



        #endregion

        #region -   Business   -

        public async Task<LoginDto> SignInAsync(LoginDto loginDto)
        {
            var userEntity = Context.Users.Where(user =>  !user.DateDeleted.HasValue)
                  .SingleOrDefault(user => loginDto.Username == user.UserName ||
                                             loginDto.Email == user.Email);
            if (userEntity is null) return null;

            var loginResult = await SignInManager.PasswordSignInAsync(userEntity, loginDto.Password, loginDto.RememberMe, false);

            if (loginResult == SignInResult.Success)
            {
                loginDto.Id = userEntity.Id;
                loginDto.Password = string.Empty;
                loginDto.Username = userEntity.UserName;
                loginDto.Email = userEntity.Email;
                loginDto.AccountType = userEntity.AccountType;
                return loginDto;
            }

            return null;
        }

        public async Task<CreateAccountDto> SignUpAsync(CreateAccountDto createAccountDto)
        {
            AccountUser accountUser = new AccountUser() {
                UserName = createAccountDto.Name,
                Email= createAccountDto.Name.ParsToJolijoberEmail(),
                AccountType= createAccountDto.AccountType,
            };

            var result = await UserManager.CreateAsync(accountUser, createAccountDto.Password);

            if (result == IdentityResult.Success) {
                createAccountDto.TextFaild = true.ToString();
            }
            else
            {
                createAccountDto.TextFaild = result.Errors.Select(e=>e.Description).ToLineString();
            }
            return createAccountDto;
        }

        #endregion


    }
}
