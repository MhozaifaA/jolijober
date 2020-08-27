using JolijoberProject.Infrastructure.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Base.Context.SqlServer
{
    /// <summary>
    /// Base DI easy to use and inject with repositories  scop life EFCore
    /// </summary>
    public class JolijoberRepository
    {
        protected readonly JolijoberDbContext Context;
        protected JolijoberRepository(JolijoberDbContext context)
        {
            Context = context;
        }
    }
}
