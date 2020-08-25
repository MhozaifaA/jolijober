using JolijoberProject.Shared.SharedKernal.EnumClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Security.Repository.DataTransferObjects
{
    public class LoginDto
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public AccountTypes AccountType { get; set; }
    }
}
