﻿using JolijoberProject.Base.Context.MongoDB;
using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Main.Repository.DataTransferObjects;
using JolijoberProject.Main.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Main.Repository.Repositores
{
    public class IdentityRepository: JolijoberRepository<Identity>, IIdentityRepository
    {

        public IdentityRepository(JolijoberService service):base(service)
        {
            
        }

        public async Task<List<IdentityDto>> GetIdentitiesAsync()
        {
            List<IdentityDto> list = new List<IdentityDto>();
            await (await Context.FindAsync(identity => true)).ForEachAsync(x => list.Add(new IdentityDto()
            {
                Id = x.Id,
                FirstName = x.FisrtName,
                SureName = x.SureName
            }));
            return list;
        }
    }
}
