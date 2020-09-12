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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AccountUser>()
                .HasIndex(u => u.SecurId)
                .IsUnique();
        }

        #endregion

        #region -   Main    -

        #endregion
    }
}
