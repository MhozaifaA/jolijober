using System;
using System.Collections.Generic;
using System.Text;

namespace JolijoberProject.Infrastructure.MongoDB.DataBase
{
    /// <summary>
    /// Configuration appsettings ,
    /// <para> collection name get Models to Plural <see cref="JolijoberProject.Infrastructure.Model"/> </para>
    /// </summary>
    public class JolijoberDatabaseSettings : IJolijoberDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        //// dbset  for collection 
        //public string IdentityCollectionName { get; set; }
    }


    /// <summary>
    /// default Configuration appsettings <see cref="JolijoberDatabaseSettings"/>
    /// </summary>
    public interface IJolijoberDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
