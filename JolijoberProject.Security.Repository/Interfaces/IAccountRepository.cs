using JolijoberProject.Security.Repository.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Security.Repository.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// login user/company with email/username
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns> will return null if not exist/allow </returns>
        Task<LoginDto> SignInAsync(LoginDto loginDto);

        /// <summary>
        /// creat new account with less details  company/user
        /// </summary>
        /// <param name="createAccountDto"></param>
        /// <returns> will return null if faild  </returns>
        Task<CreateAccountDto> SignUpAsync(CreateAccountDto createAccountDto);
    }
}
