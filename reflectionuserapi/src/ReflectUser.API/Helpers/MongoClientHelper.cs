using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ReflectUser.API.Helpers.Interfaces;
using ReflectUser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace ReflectUser.API.Helpers
{
    internal class MongoClientHelper<TRequest> : IMongoClientHelper<TRequest>
    {

        private readonly IMongoDatabase _mongoDb;
        public MongoClientHelper(IOptions<MongoDbSettings> settings)
        {
            IMongoClient mongoClient = new MongoClient(settings.Value.ConnectionString);
            _mongoDb = mongoClient.GetDatabase(settings.Value.DbName);
        }

        public void InsertOne(TRequest request, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).InsertOne(request);

        public List<TRequest> GetUserDataById(FilterDefinition<TRequest> filters, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).Find<TRequest>(filters).ToList();

        public List<TRequest> GetUserData(string collection)
        {
            return _mongoDb.GetCollection<TRequest>(collection).Find(FilterDefinition<TRequest>.Empty).ToList();
        }

        public void InsertMany(List<TRequest> request, string collectionName)
            => _mongoDb.GetCollection<TRequest>(collectionName).InsertMany(request);

    }
}
