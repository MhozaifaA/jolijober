using JolijoberProject.Shared.SharedKernal.EnumClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Security.Repository.DataTransferObjects
{
    public class CreateAccountDto
    {
        /// <summary>
        /// Full Name / Company Name
        /// </summary>
        public string Name { get; set; }
        public string Country{ get; set; }
        public string Password{ get; set; }
        public AccountTypes AccountType { get; set; }

        /// <summary>
        /// string ot true  if false  will take error text
        /// </summary>
        public string TextFaild { get; set; }
        public bool IsFaild => bool.TryParse(TextFaild, out _);
    }
}
