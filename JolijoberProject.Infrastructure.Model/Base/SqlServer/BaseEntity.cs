using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JolijoberProject.Infrastructure.Model.Base.SqlServer
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset DateDeleted { get; set; }
    }
}
