using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Main.Repository.DataTransferObjects
{
    public class PostMiniDto
    {
        public string Id{ get; set; }
        public string Descreption { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public long Likes { get; set; }
        public long Views { get; set; }
        public long Comments { get; set; }
    }
}
