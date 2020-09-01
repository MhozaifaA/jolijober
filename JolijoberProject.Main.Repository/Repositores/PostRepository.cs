using JolijoberProject.Base.Context.MongoDB;
using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Main.Repository.Interface;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Entities;
using MongoDB.Bson;
using System.Linq;
using JolijoberProject.Main.Repository.DataTransferObjects;

namespace JolijoberProject.Main.Repository.Repositores
{
    public class PostRepository : JolijoberRepository<Post>, IPostRepository
    {
        public PostRepository(JolijoberService context) : base(context)
        { }

        public async Task<PostMiniDto> GetPostByIdMiniAsync(string id)
        {
            var post = await Context.Find(post => post.Id == id).SingleOrDefaultAsync<Post>();
            return new PostMiniDto()
            {
                Date = post.Date,
                Title = post.Title,
                Tags = post.Tags,
                Views = post.Views,
                Comments = post.Comments,
                Likes = post.Likes,
                Descreption = post.Descreption,
                Id = post.Id
            };


        }

        public async Task<List<PostMiniDto>> GetPostsMiniAsync()
        {
            return await Context.AsQueryable().Select(post => new PostMiniDto()
            {
                Date = post.Date,
                Title = post.Title,
                Tags = post.Tags,
                Views = post.Views,
                Comments = post.Comments,
                Likes = post.Likes,
                Descreption = post.Descreption,
                Id = post.Id
            }).ToListAsync();
        }
    }
}
