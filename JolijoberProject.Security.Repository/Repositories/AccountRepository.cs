using JolijoberProject.Base.Context.SqlServer;
using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.Model.Security;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Infrastructure.SqlServer.DataBase;
using JolijoberProject.Security.Repository.DataTransferObjects;
using JolijoberProject.Security.Repository.Interfaces;
using JolijoberProject.Shared.SharedKernal.ExtensionMethod;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using PluralizeService.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Security.Repository.Repositories
{
    public class AccountRepository : JolijoberRepository, IAccountRepository ,IDisposable
    {
        #region -   Constructor   -

        public UserManager<AccountUser> UserManager { get; }
        public SignInManager<AccountUser> SignInManager { get; }
        private RoleManager<AccountRole> RoleManager { get; }


        private readonly IMongoCollection<Identity> contextmongodb;


        public AccountRepository(JolijoberDbContext context,
            UserManager<AccountUser> userManager, SignInManager<AccountUser> signInManager, RoleManager<AccountRole> roleManager,
            JolijoberService contextmongodb) : base(context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;


            this.contextmongodb = contextmongodb.MongoService.GetCollection<Identity>(PluralizationProvider.Pluralize(nameof(Identity)));
        }



        #endregion

        #region -   Business   -

        public async Task<LoginDto> SignInAsync(LoginDto loginDto)
        {
            var userEntity = Context.Users.Where(user => !user.DateDeleted.HasValue)
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
            AccountUser accountUser = new AccountUser()
            {
                UserName = createAccountDto.UserName,
                Email = createAccountDto.UserName.ParsToJolijoberEmail(),
                AccountType = createAccountDto.AccountType,
            };

            var result = await UserManager.CreateAsync(accountUser, createAccountDto.Password);

            if (result == IdentityResult.Success)
            {
                createAccountDto.TextFaild = true.ToString();

                contextmongodb.InsertOne(new Identity()
                {
                    FisrtName = accountUser.Email,
                    SureName = string.Empty,
                    SecurId = accountUser.Id,
                    Type= accountUser.AccountType,
                    Country= createAccountDto.Country
                });

            }
            else
            {
                createAccountDto.TextFaild = result.Errors.Select(e => e.Description).ToLineString();
            }
            return createAccountDto;
        }

        public async Task<bool> SignOutAsync(string? id= null)
        {
            await  SignInManager.SignOutAsync();
            return true;
        }

        #endregion


        #region -   Dispose   -

        private bool disposed = false;
        /// <summary>
        /// Implements the dipose pattern.
        /// </summary>
        /// <param name="disposing"><c>True</c> when disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                  Context.Dispose();
            this.disposed = true;
        }

        /// <summary>
        /// Implement <see cref="IDisposable"/>.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
