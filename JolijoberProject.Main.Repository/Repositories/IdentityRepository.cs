﻿using JolijoberProject.Base.Context.MongoDB;
using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using JolijoberProject.Main.Repository.DataTransferObjects;
using JolijoberProject.Main.Repository.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolijoberProject.Main.Repository.Repositories
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

            return await Context.AsQueryable().Select(x => new IdentityDto()
            {
                Id = x.Id,
                FirstName = x.FisrtName,
                SureName = x.SureName
            }).ToListAsync();
        }

        public async Task<ProfileDto> GetProfile(string Id)
        {

            //await Context.Indexes.CreateOneAsync(
            //    Builders<Identity>.IndexKeys
            //        .Ascending(i => i.SecurId),
            //    new CreateIndexOptions<Identity>
            //    {
            //        Unique = true,
            //    });

            var identity = await Context.AsQueryable().FirstOrDefaultAsync(identity => identity.SecurId == Id);
            identity = identity ?? new Identity();
            return new ProfileDto()
            {
                FirstName = identity?.FisrtName??"",
                SureName = identity?.SureName??"",
                CoverImagePath = identity?.CoverImagePath??"",
                ProfileImagePath = identity?.ProfileImagePath??"",
                Headline= identity?.Headline??"",
                Overview=identity?.Overview??"",
                Following = identity.Following?.Select(x=>x.ToString()).ToArray(),
                Followers= identity.Followers?.Select(x=>x.ToString()).ToArray(),
            };
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

    }
}
