using JolijoberProject.Infrastructure.Model.Base.MongoDB;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Infrastructure.Model.Main
{
    public class Identity : BaseEntity
    {
      
        public string FisrtName { get; set; }
        public string SureName { get; set; }
        public string Country { get; set; }
        public string SecurId { get; set; }
        public AccountTypes Type { get; set; }

        //[BsonIgnore]
        //public string FullName => FisrtName + " " + SureName;
    }
}
