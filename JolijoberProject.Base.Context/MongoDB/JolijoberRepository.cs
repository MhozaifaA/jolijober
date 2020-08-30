using JolijoberProject.Infrastructure.Model.Base.MongoDB;
using JolijoberProject.Infrastructure.MongoDB.DataBase;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using PluralizeService.Core;

namespace JolijoberProject.Base.Context.MongoDB
{
    /// <summary>
    /// Base DI Generic <see cref="T"/>  get collection with Plural entities  <see cref="JolijoberProject.Infrastructure.Model"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JolijoberRepository<T> where T:BaseEntity
    {
        protected readonly IMongoCollection<T> Context;
        protected JolijoberRepository(JolijoberService context)
        {
            Context = context.MongoService.GetCollection<T>(PluralizationProvider.Pluralize(typeof(T).Name));
        }
    }



    /// <summary>
    /// Base DI Generics <see cref="T1"/> , <see cref="T2"/>   get collection with Plural entities  <see cref="JolijoberProject.Infrastructure.Model"/>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class JolijoberRepository<T1,T2> where T1 :BaseEntity  where T2 :BaseEntity
    {
        protected readonly IMongoCollection<T1> Context1;
        protected readonly IMongoCollection<T2> Context2;
        protected JolijoberRepository(JolijoberService context)
        {
            Context1 = context.MongoService.GetCollection<T1>(PluralizationProvider.Pluralize(typeof(T1).Name));
            Context2 = context.MongoService.GetCollection<T2>(PluralizationProvider.Pluralize(typeof(T2).Name));
        }
    }



    /// <summary>
    /// Base DI Generics <see cref="T1"/> , <see cref="T2"/> , <see cref="T3"/>   get collection with Plural entities  <see cref="JolijoberProject.Infrastructure.Model"/>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class JolijoberRepository<T1, T2,T3> where T1 :BaseEntity where T2 :BaseEntity where T3 :BaseEntity
    {
        protected readonly IMongoCollection<T1> Context1;
        protected readonly IMongoCollection<T2> Context2;
        protected readonly IMongoCollection<T3> Context3;
        protected JolijoberRepository(JolijoberService context)
        {
            Context1 = context.MongoService.GetCollection<T1>(PluralizationProvider.Pluralize(typeof(T1).Name));
            Context2 = context.MongoService.GetCollection<T2>(PluralizationProvider.Pluralize(typeof(T2).Name));
            Context3 = context.MongoService.GetCollection<T3>(PluralizationProvider.Pluralize(typeof(T3).Name));
        }
    }




    /// <summary>
    /// Base DI Generics <see cref="T1"/> , <see cref="T2"/> , <see cref="T3"/>  , <see cref="T4"/>   get collection with Plural entities  <see cref="JolijoberProject.Infrastructure.Model"/>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public class JolijoberRepository<T1, T2, T3,T4> where T1 :BaseEntity where T2 :BaseEntity where T3 :BaseEntity where T4 :BaseEntity
    {
        protected readonly IMongoCollection<T1> Context1;
        protected readonly IMongoCollection<T2> Context2;
        protected readonly IMongoCollection<T3> Context3;
        protected readonly IMongoCollection<T4> Context4;
        protected JolijoberRepository(JolijoberService context)
        {
            Context1 = context.MongoService.GetCollection<T1>(PluralizationProvider.Pluralize(typeof(T1).Name));
            Context2 = context.MongoService.GetCollection<T2>(PluralizationProvider.Pluralize(typeof(T2).Name));
            Context3 = context.MongoService.GetCollection<T3>(PluralizationProvider.Pluralize(typeof(T3).Name));
            Context4 = context.MongoService.GetCollection<T4>(PluralizationProvider.Pluralize(typeof(T4).Name));
        }
    }


}
