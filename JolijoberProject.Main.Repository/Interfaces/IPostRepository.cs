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
        Task<PostMiniDto> GetPostByIdMiniAsync(string id);
    }
}
