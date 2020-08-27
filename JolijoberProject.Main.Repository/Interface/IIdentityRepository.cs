using JolijoberProject.Main.Repository.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Main.Repository.Interface
{
    public interface IIdentityRepository
    {
       Task<List<IdentityDto>> GetIdentitiesAsync();
    }
}
