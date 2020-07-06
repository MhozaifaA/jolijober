using JolijoberProject.Infrastructure.Model.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Infrastructure.SqlServer.DataBase
{
    public class JolijoberDbContext : IdentityDbContext<AccountUser, AccountRole, string, AccountUserClaim, AccountUserRole
                                                     , AccountUserLogin, AccountRoleClaim, AccountUserToken>  // GUID
    {

        #region -   Constructor    -

        public JolijoberDbContext(DbContextOptions<JolijoberDbContext> options) : base(options)
        {

        }

        #endregion

        #region -   Main    -

        #endregion
    }
}
