using JolijoberProject.Infrastructure.Model.Base.MongoDB;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.SharedModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Infrastructure.Model.Main
{
    public class Post : BaseEntity
    {
        public DateTime Date { get; set; } ///used
        public string Title { get; set; } ///used
        public MinMax Sallaries { get; set; } = new MinMax(); ///used //object max min
        public Availabilties Availabilty { get; set; }
        public string Descreption { get; set; } ///used

        public string[] Tags { get; set; } = new string[] { }; ///used
        public string[] Specifications { get; set; } = new string[] { }; ///used  //Epic Coder
        public string Region { get; set; }///used 

        public  Like[] Likes { get; set; } = new Like[] { }; ///used  //collection  user
        public Comment[] Comments { get; set; } = new Comment[] { }; ///used   //collection of collection commet
        public long Views { get; set; } ///used   //collection of collection commet


        public AccountTypes AccountType { get; set; } ///used , // posted from user/company
        public string AccountId { get; set; }///used
        public string AccountName { get; set; }///used
        public PostTypes PostType { get; set; } ///used




        public MinMax Hours { get; set; }//max min
        public string KindPay { get; set; } //object max min
        public string[] Skills { get; set; } = new string[] { };

        public string[] Categories { get; set; } = new string[] { }; // collection  like sofware en



    }


}
