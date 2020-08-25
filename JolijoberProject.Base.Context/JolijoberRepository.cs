using JolijoberProject.Infrastructure.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Base.Context
{
    public class JolijoberRepository
    {
        protected readonly JolijoberDbContext Context;
        protected JolijoberRepository(JolijoberDbContext context)
        {
            Context = context;
        }
    }
}
