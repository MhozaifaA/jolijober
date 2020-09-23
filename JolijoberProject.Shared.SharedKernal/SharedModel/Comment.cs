using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Shared.SharedKernal.SharedModel
{
    public class Comment
    {
        public string CommenterId { get; set; }
        public string Commenter { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public Comment[] ChildComments { get; set; }= new Comment[] { };
    }
}
