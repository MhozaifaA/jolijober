using JolijoberProject.Infrastructure.MongoDB;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Main.Repository.DataTransferObjects;
using JolijoberProject.Main.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jolijober.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IPostRepository _postRepository;

        public JsonController(IIdentityRepository identityRepository, IPostRepository postRepository)
        {
             _identityRepository = identityRepository;
            _postRepository = postRepository;
        }
        ////https://localhost:44349/api/Json/GetIdentities
        ///
        [HttpGet]
        public async Task<ActionResult<List<IdentityDto>>> GetIdentities() =>
            await _identityRepository.GetIdentitiesAsync();

        //https://localhost:44349/api/Json/GetPosts
        [HttpGet]
        public async Task<ActionResult<List<PostMiniDto>>> GetPosts() =>
         await _postRepository.GetPostsMiniAsync();
    }
}
