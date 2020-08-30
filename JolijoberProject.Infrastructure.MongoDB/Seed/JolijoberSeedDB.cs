using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.Model.Shared;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
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

          var  ContextPost = context.MongoService.GetCollection<Post>(PluralizationProvider.Pluralize(typeof(Post).Name));

            IEnumerable<Post> posts = new List<Post>()
            {
                new Post(){ Title="offer for job in c# " ,Descreption="offer for job in c# offer for job in c# offer for job in c# offer for job in c# ", 
                    Tags= new[]{"C#","wpf" }  ,  Date=DateTime.Now, Comments="108" , Likes="16k" ,Views="17k" , Hours= new MinMax(4,6), Sallaries=new MinMax(600,800) ,   },


                   new Post(){ Title="offer for job in cphp " ,Descreption="offer for job in cphp offer for job in cphp offer for job in cphpoffer for job in cphp ",
                    Tags= new[]{"php","laravl" , "mysql" ,"database" }  ,  Date=DateTime.Now, Comments="108" , Likes="16k" ,Views="17k" , Hours= new MinMax(4,6), Sallaries=new MinMax(600,800) ,   },

            };

          await  ContextPost.InsertManyAsync(posts);
        }
    }
}
