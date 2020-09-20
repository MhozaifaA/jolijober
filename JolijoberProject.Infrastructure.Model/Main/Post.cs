using JolijoberProject.Infrastructure.Model.Base.MongoDB;
using JolijoberProject.Infrastructure.Model.Shared;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Infrastructure.Model.Main
{
    public class Post : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Descreption { get; set; }

        public string[] Tags { get; set; } // php 
        public string[] Specifications { get; set; }

        public MinMax Hours { get; set; }//max min
        public MinMax Sallaries { get; set; } //object max min
        public string KindPay { get; set; } //object max min
        public string[] Skills { get; set; } 

        public string[] Categories { get; set; } // collection  like sofware en
        public string Likes { get; set; } //collection  user
        public string Comments { get; set; }  //collection of collection commet
        public string Views { get; set; }  //collection of collection commet

        public AccountTypes AccountType { get; set; } // posted from user/company
        public string AccountId { get; set; }
    }


}
