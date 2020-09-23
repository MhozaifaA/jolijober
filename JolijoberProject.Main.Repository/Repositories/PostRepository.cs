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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using JolijoberProject.Shared.SharedKernal.SharedModel;
using JolijoberProject.Shared.SharedKernal.ExtensionMethod;

namespace JolijoberProject.Main.Repository.Repositories
{
    public class PostRepository : JolijoberRepository<Post,Identity>, IPostRepository
    {

        private readonly IHttpContextAccessor httpContextAccessor;
        public PostRepository(JolijoberService service, IHttpContextAccessor httpContextAccessor) : base(service)
        { this.httpContextAccessor = httpContextAccessor; }

        public async Task<PostMiniDto> GetPostByIdMiniAsync(string id)
        {
            var post = await Context1.Find(post => post.Id == id).SingleOrDefaultAsync<Post>();
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
            await Context1.Find(post => true).SortByDescending(post=>post.Date).ForEachAsync(post => list.Add(new PostMiniDto()
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


            return await Context1.AsQueryable().Select(post => new PostMiniDto()
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

        public async Task<List<PostDto>> GetPostsAsync(bool IsJob = true, bool IsProject = true)
        {
            List<PostDto> list = new List<PostDto>();
            var filterBuilder = Builders<Post>.Filter;

            var filter =IsJob&&IsProject?((filterBuilder.Eq(x=>x.PostType, PostTypes.Job) | filterBuilder.Eq(x => x.PostType, PostTypes.Project)))
                :(IsJob? filterBuilder.Eq(x => x.PostType, PostTypes.Job): filterBuilder.Eq(x => x.PostType, PostTypes.Project))  ;

            await Context1.Find(filter)
                .SortByDescending(post => post.Date).ForEachAsync(post => list.Add(new PostDto()
            {
                Id=post.Id,
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

        public async Task<PostDto> AddPostAsync(PostDto post)
        {

          string Id=httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

           var Account=  await Context2.Find(x => x.SecurId == Id).SingleOrDefaultAsync();

            var set = new Post()
            {
                Date = post.Date,
                Title = post.Title,
                Tags = post.Tags,
                Views = post.Views,

                AccountId = Account.Id,
                AccountName = Account.FisrtName+" "+Account.SureName,
                AccountType = Account.Type,


                PostType = post.PostType,
                Availabilty = post.Availabilty,
                Categories = post.Categories,
                Comments = post.Comments,
                Descreption = post.Descreption,
                Hours = post.Hours,
                KindPay = post.KindPay,
                Likes = post.Likes,
                Region = post.Region,
                Sallaries = post.Sallaries,
                Skills = post.Skills,
                Specifications = post.Specifications
            };
             await Context1.InsertOneAsync(set);

            post.Id = set.Id;
            return post;
        }

        public async Task<List<PostDto>> GetPostsFilterAsync(FilterDto filter)
        {
            List<PostDto> list = new List<PostDto>();
            var filterBuilder = Builders<Post>.Filter;

            var exfilter = filterBuilder.Eq(x => x.PostType, PostTypes.Job);

            var exfilterd=
            (filterBuilder.Eq(x => x.Title, filter.Title) | filterBuilder.ElemMatch(x => x.Tags, filter.Tag)|
                filterBuilder.Eq(x => x.Region, filter.Region) | filterBuilder.ElemMatch(x => x.Specifications, filter.Specification)
                | filterBuilder.Eq(x => x.Sallaries, new MinMax(filter.Min, filter.Max)) | filterBuilder.Eq(x => x.Availabilty, filter.Availabilty));


            await Context1.Find(exfilter)
                .SortByDescending(post => post.Date).ForEachAsync(post => list.Add(new PostDto()
                {
                    Id = post.Id,
                    Date = post.Date,
                    Title = post.Title,
                    Tags = post.Tags,
                    Views = post.Views,
                    AccountId = post.AccountId,
                    PostType = post.PostType,
                    AccountName = post.AccountName,
                    AccountType = post.AccountType,
                    Availabilty = post.Availabilty,
                    Categories = post.Categories,
                    Comments = post.Comments,
                    Descreption = post.Descreption,
                    Hours = post.Hours,
                    KindPay = post.KindPay,
                    Likes = post.Likes,
                    Region = post.Region,
                    Sallaries = post.Sallaries,
                    Skills = post.Skills,
                    Specifications = post.Specifications
                }));

            list= list.Where(x =>  x.Availabilty == filter.Availabilty &&
             x.Title.Contains(filter.Title??"")).ToList();

            return list;
        }

        public async Task<List<PostDto>> GetPostsSearchAsync(string text)
        {
            List<PostDto> list = new List<PostDto>();

            var AllPost = await Context1.AsQueryable().ToListAsync();
            var QueryTuple = AllPost.Select(x => (x.Id, x.Descreption??"")).ToList();
           var Ids = JolijoberExtensions.FuzzySearchLinq(text,QueryTuple, 0.7).Select(x=>x.Item1);
            bool ifff = Ids.Any();
          list= AllPost.Where(x => ifff?Ids.Contains(x.Id): x.Descreption?.Contains(text)??false).OrderByDescending(post => post.Date).Select(post=>new PostDto()
            {
                Id = post.Id,
                Date = post.Date,
                Title = post.Title,
                Tags = post.Tags,
                Views = post.Views,
                AccountId = post.AccountId,
                PostType = post.PostType,
                AccountName = post.AccountName,
                AccountType = post.AccountType,
                Availabilty = post.Availabilty,
                Categories = post.Categories,
                Comments = post.Comments,
                Descreption = post.Descreption,
                Hours = post.Hours,
                KindPay = post.KindPay,
                Likes = post.Likes,
                Region = post.Region,
                Sallaries = post.Sallaries,
                Skills = post.Skills,
                Specifications = post.Specifications
            }).ToList();
            return list;
        }
    }
}
