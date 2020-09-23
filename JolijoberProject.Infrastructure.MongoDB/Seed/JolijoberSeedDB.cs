using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Shared.SharedKernal.EnumClass;
using JolijoberProject.Shared.SharedKernal.SharedModel;
using MongoDB.Driver;
using PluralizeService.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Infrastructure.MongoDB.Seed
{
    public static class JolijoberSeedDB
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var context = (JolijoberService)services.GetService(typeof(JolijoberService));

            var ContextPost = context.MongoService.GetCollection<Post>(PluralizationProvider.Pluralize(typeof(Post).Name));
            long count = await ContextPost.CountAsync(x=>true);
            IEnumerable<Post> posts = new List<Post>()
            {
               new Post(){
                Date=DateTime.Now,
                Title="مطور تطبيقات ويب" ,
                Sallaries=new MinMax(600,800) ,
                Availabilty=Availabilties.FullTime,
                Descreption="خبرة في مجال الويب شغف يعمل بجد يحتاج لإتمام إطارين عمل على الاقل يفضل ان يكون خريج والخبرة جيدة في الدوت نت",
                Tags= new[]{"C#","dotNet" }  ,
                Specifications=new[]{ "مطور ويب كامل" },
                Region="سوريا-حلب" ,
                //Likes= new Like[]{ },
                //Comments= new Comment[]{ },
                Views=0,
                AccountId="894545456" ,
                AccountName= "طيب الطيب",
                AccountType=AccountTypes.User,
                PostType=PostTypes.Job},

                 new Post(){
                Date=DateTime.Now,
                Title="مطور تطبيقات اندرويد" ,
                Sallaries=new MinMax(200,400) ,
                Availabilty=Availabilties.PartTime,
                Descreption="خبير في تطبيقات الاتدرويد يتقن استخلاص واجهات جميلة",
                Tags= new[]{"Java","Android" }  ,
                Specifications=new[]{ "مطور تطبيقات اندرويد" },
                Region="سوريا-دمشق" ,
                 Likes= new Like[]{ new Like() { Liker="طيب الطيب" ,LikerId= "asd8489" } },
                Comments= new Comment[]{
                    new Comment() { CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad", },
                   new Comment() { CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad",
                   ChildComments= new Comment[]{  new Comment() {
                       CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad",
                       ChildComments  = new Comment[] {
                           new Comment() {
                               CommenterId = "asd8489", Commenter = "طيب الطيب", Date = DateTime.Now, Text = "asdad"},
                           new Comment() { CommenterId = "asd8489", Commenter = "طيب الطيب", Date = DateTime.Now, Text = "asdad", }
                       } }, new Comment() { CommenterId = "asd8489", Commenter = "طيب الطيب", Date = DateTime.Now, Text = "asdad", } }
                   }
                         ,new Comment() { CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad", },
                },
                Views=0,
                AccountId="86545112",
                AccountName= "محمد حذيفة أصيل",
                AccountType=AccountTypes.User,
                PostType=PostTypes.Job},



                    new Post(){
                Date=DateTime.Now,
                Title="مطور تطبيقات اندرويد" ,
                Sallaries=new MinMax(200,400) ,
                Availabilty=Availabilties.PartTime,
                Descreption="خبير في تطبيقات الاتدرويد يتقن استخلاص واجهات جميلة",
                Tags= new[]{"Java","Android" }  ,
                Specifications=new[]{ "مطور تطبيقات اندرويد" },
                Region="سوريا-دمشق" ,
                 Likes= new Like[]{ new Like() { Liker="طيب الطيب" ,LikerId= "asd8489" } },
                Comments= new Comment[]{
                    new Comment() { CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad", },
                   new Comment() { CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad",
                   ChildComments= new Comment[]{  new Comment() {
                       CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad",
                       ChildComments  = new Comment[] {
                           new Comment() {
                               CommenterId = "asd8489", Commenter = "طيب الطيب", Date = DateTime.Now, Text = "asdad"},
                           new Comment() { CommenterId = "asd8489", Commenter = "طيب الطيب", Date = DateTime.Now, Text = "asdad", }
                       } }, new Comment() { CommenterId = "asd8489", Commenter = "طيب الطيب", Date = DateTime.Now, Text = "asdad", } }
                   }
                         ,new Comment() { CommenterId= "asd8489", Commenter="طيب الطيب",Date=DateTime.Now,Text="asdad", },
                },
                Views=0,
                AccountId="86545112",
                AccountName= "محمد حذيفة أصيل",
                AccountType=AccountTypes.User,
                PostType=PostTypes.Job},
            };
           if (count==0)
            await ContextPost.InsertManyAsync(posts);
        }
    }
}
