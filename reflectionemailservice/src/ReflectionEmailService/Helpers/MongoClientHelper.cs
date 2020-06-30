using CognizantReflect.Api.Helpers.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ReflectionEmailService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace CognizantReflect.Api.Helpers
{
    internal class MongoClientHelper<TRequest> : IMongoClientHelper<TRequest>
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoClientHelper(IOptions<envSettings> options)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(options.Value.ConnectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            _mongoDb = mongoClient.GetDatabase(options.Value.DbName);
        }


        public IMongoCollection<TRequest> GetMongoCollection(string collection)
            => _mongoDb.GetCollection<TRequest>(collection);

        public void InsertOne(TRequest request, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).InsertOne(request);

        public BsonDocument GetRecords(string collection,string type)
        {
            var template = _mongoDb.GetCollection<BsonDocument>(collection);

            var filter = Builders<BsonDocument>.Filter.Eq("type", type);

            return template.Find(filter).FirstOrDefault();
        }

        public List<TRequest> GetData(string collection, string type, FilterDefinition<TRequest> filters)
            => _mongoDb.GetCollection<TRequest>(collection).Find(filters).ToList();

        public void UpdateOne(UpdateDefinition<TRequest> update,FilterDefinition<TRequest> filter, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).UpdateOne(filter,update);

    }
}
