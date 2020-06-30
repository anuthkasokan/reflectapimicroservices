using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CognizantReflect.Api.Helpers
{
    internal class MongoClientHelper<TRequest> : IMongoClientHelper<TRequest>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDb;
        public MongoClientHelper(IOptions<MongoDbSettings> settings)
        {
            _mongoClient = new MongoClient(settings.Value.ConnectionString);
            _mongoDb = _mongoClient.GetDatabase(settings.Value.DbName);
        }

        public IMongoCollection<TRequest> GetMongoCollection(string collection)
            => _mongoDb.GetCollection<TRequest>(collection);

        public void InsertOne(TRequest request, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).InsertOne(request);

        public void InsertAll(List<TRequest> request, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).InsertMany(request);

        public void Delete(FilterDefinition<TRequest> filter, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).DeleteMany(filter);

        public void UpdateOne(UpdateDefinition<TRequest> update,FilterDefinition<TRequest> filter, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).UpdateOne(filter, update);

        public List<TRequest> GetData(FilterDefinition<TRequest> filters, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).Find<TRequest>(filters)?.ToList();

        public List<TRequest> GetDataBySorting(FilterDefinition<TRequest> filters, SortDefinition<TRequest> sortBy,
            string collection)
            => _mongoDb.GetCollection<TRequest>(collection).Find(filters)?.Sort(sortBy).ToList();

        //public List<TRequest> GetTotalRecords(string collection)
        //=> _mongoDb.GetCollection<TRequest>(collection).Find(FilterDefinition<TRequest>.Empty).ToList();

        public long GetDocumentCount(FilterDefinition<TRequest> filters, string collectionName)
            => _mongoDb.GetCollection<TRequest>(collectionName).CountDocuments(filters);

        public List<BsonDocument> GetTotalRecords(string collection)
            => _mongoDb.GetCollection<BsonDocument>(collection).Find(new BsonDocument()).ToList();

        public BsonDocument GetSingleRecord(string collection, FilterDefinition<BsonDocument> filter)
            => _mongoDb.GetCollection<BsonDocument>(collection).Find(filter).FirstOrDefault();
        public List<BsonDocument> GetRecords(string collection, FilterDefinition<BsonDocument> filter)
            => _mongoDb.GetCollection<BsonDocument>(collection).Find(filter).ToList();

        public TRequest GetLatestId(string collectionName, SortDefinition<TRequest> sortBy)
        {
            var ret = _mongoDb.GetCollection<TRequest>(collectionName).Find(new BsonDocument()).Sort(sortBy).FirstOrDefault();

            return ret;
        }

    }
}
