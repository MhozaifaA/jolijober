using JolijoberProject.Infrastructure.Model.Base.MongoDB;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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



        #region Profile

        public string Headline { get; set; }

        public string Overview { get; set; }

        public string CoverImagePath { get; set; }
        public string ProfileImagePath { get; set; }


        public ObjectId[] Following { get; set; }
        public ObjectId[] Followers { get; set; }

        #endregion
    }
}
