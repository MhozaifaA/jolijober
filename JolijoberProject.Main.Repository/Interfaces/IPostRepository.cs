using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Main.Repository.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Main.Repository.Interfaces
{
    public  interface IPostRepository
    {
        Task<List<PostMiniDto>> GetPostsMiniAsync();
        Task<List<PostDto>> GetPostsAsync(bool IsJob=true, bool IsProject = true);

        Task<List<PostDto>> GetPostsFilterAsync(FilterDto filter);
        Task<List<PostDto>> GetPostsSearchAsync(string text);

        Task<PostMiniDto> GetPostByIdMiniAsync(string id);
        Task<PostDto> AddPostAsync(PostDto post);
    }
}
