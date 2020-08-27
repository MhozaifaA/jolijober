using JolijoberProject.Infrastructure.Model.Main;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Infrastructure.MongoDB.DataBase
{
    /// <summary>
    /// context with mongoDB lifetime 
    /// </summary>
    public class JolijoberService
    {
        public IMongoDatabase MongoService;
        public JolijoberService(IJolijoberDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            MongoService = client.GetDatabase(settings.DatabaseName);
        }
    }
}
