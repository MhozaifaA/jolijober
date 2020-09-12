using JolijoberProject.Shared.SharedKernal.EnumClass;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Infrastructure.Model.Security
{
    public class AccountUser : IdentityUser // Guid <string>
    {
        #region -   BaseEntity   -

        public DateTimeOffset? DateDeleted { get; set; }

        #endregion
        /// <summary>
        ///  mongodb_Id  <c>ObjectId</c>  identity collection
        /// </summary>
        public string SecurId { get; set; } // mongodb_Id
        public AccountTypes AccountType { get; set; }

    }
}
