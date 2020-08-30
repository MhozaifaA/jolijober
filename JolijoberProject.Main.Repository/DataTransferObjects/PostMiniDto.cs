using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Main.Repository.DataTransferObjects
{
    public class PostMiniDto
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public string Likes { get; set; }
        public string Comments { get; set; }
        public string Views { get; set; }
    }
}
