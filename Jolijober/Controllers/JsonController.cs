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
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        private readonly IIdentityRepository _identityRepository;

        public JsonController(IIdentityRepository identityRepository)
        {
             _identityRepository = identityRepository;
        }
        ////https://localhost:44349/api/Json
        [HttpGet]
        public async Task<ActionResult<List<IdentityDto>>> Get() =>
            await _identityRepository.GetIdentitiesAsync();
    }
}
