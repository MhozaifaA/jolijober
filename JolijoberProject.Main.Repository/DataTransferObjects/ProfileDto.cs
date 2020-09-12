using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Main.Repository.DataTransferObjects
{
    public class ProfileDto
    {
        public string FirstName{ get; set; }
        public string SureName{ get; set; }
        public string FullName => $"{FirstName} {SureName}";


        public string Headline { get; set; }

        public string CoverImagePath { get; set; }
        public string ProfileImagePath { get; set; }

        public string[] Following { get; set; }
        public string[] Followers { get; set; }
    }
}
