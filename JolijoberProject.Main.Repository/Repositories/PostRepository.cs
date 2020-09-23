using JolijoberProject.Base.Context.MongoDB;
using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Main.Repository.Interfaces;
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
using JolijoberProject.BoundedContext.Extension;
using JolijoberProject.Shared.SharedKernal.EnumClass;

namespace JolijoberProject.Main.Repository.Repositories
{
    public class PostRepository : JolijoberRepository<Post>, IPostRepository
    {
        public PostRepository(JolijoberService service) : base(service)
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
                Likes = post.Likes.LongCount(),
                Descreption = post.Descreption,
                Id = post.Id,
                Comments= post.Comments.LongCount(),
            };


        }

        public async Task<List<PostMiniDto>> GetPostsMiniAsync()
        {
           
            List<PostMiniDto> list = new List<PostMiniDto>();
            await Context.Find(post => true).SortByDescending(post=>post.Date).ForEachAsync(post => list.Add(new PostMiniDto()
            {
                Date = post.Date,
                Title = post.Title,
                Tags = post.Tags,
                Views = post.Views,
                Comments = post.Comments.HierarchyCount(),
                Likes = post.Likes.LongCount(),
                Descreption = post.Descreption,
                Id = post.Id
            }));
            return list;


            return await Context.AsQueryable().Select(post => new PostMiniDto()
            {
                Date = post.Date,
                Title = post.Title,
                Tags = post.Tags,
                Views = post.Views,
                Comments =post.Comments.HierarchyCount(),
                Likes =post.Likes.LongCount(),
                Descreption = post.Descreption,
                Id = post.Id
            }).ToListAsync();
        }



        private bool disposed = false;
        /// <summary>
        /// Implements the dipose pattern.
        /// </summary>
        /// <param name="disposing"><c>True</c> when disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing) { }
                    //Context.Dispose();
            this.disposed = true;
        }

        /// <summary>
        /// Implement <see cref="IDisposable"/>.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task<List<PostDto>> GetPostsAsync(bool IsJob = true, bool IsProject = true)
        {
            List<PostDto> list = new List<PostDto>();
            var filterBuilder = Builders<Post>.Filter;

            var filter =IsJob&&IsProject?((filterBuilder.Eq(x=>x.PostType, PostTypes.Job) | filterBuilder.Eq(x => x.PostType, PostTypes.Project)))
                :(IsJob? filterBuilder.Eq(x => x.PostType, PostTypes.Job): filterBuilder.Eq(x => x.PostType, PostTypes.Project))  ;

            await Context.Find(filter)
                .SortByDescending(post => post.Date).ForEachAsync(post => list.Add(new PostDto()
            {
                Date = post.Date,
                Title = post.Title,
                Tags = post.Tags,
                Views = post.Views,
                AccountId=post.AccountId,
                PostType=post.PostType,
                AccountName=post.AccountName,
                AccountType=post.AccountType,
                Availabilty=post.Availabilty,
                Categories=post.Categories,
                Comments=post.Comments,
                Descreption=post.Descreption,
                Hours=post.Hours,
                KindPay=post.KindPay,
                Likes=post.Likes,
                Region=post.Region,
                Sallaries=post.Sallaries,
                Skills=post.Skills,
                Specifications=post.Specifications
            }));
            return list;
        }
    }
}
