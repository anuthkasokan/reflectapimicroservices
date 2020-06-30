using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ReflectionFeedback.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ReflectionFeedback.Api.Helpers
{
    internal class MongoClientHelper<TRequest> : IMongoClientHelper<TRequest>
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoClientHelper(IOptions<MongoDbSettings> settings)
        {
            IMongoClient mongoClient = new MongoClient(settings.Value.ConnectionString);
            _mongoDb = mongoClient.GetDatabase(settings.Value.DbName);
        }

        public IMongoCollection<TRequest> GetMongoCollection(string collection)
            => _mongoDb.GetCollection<TRequest>(collection);

        public void InsertOne(TRequest request, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).InsertOne(request);

        public void UpdateOne(UpdateDefinition<TRequest> update,FilterDefinition<TRequest> filter, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).UpdateOne(filter, update);

        public List<TRequest> GetData(FilterDefinition<TRequest> filters, string collection)
            => _mongoDb.GetCollection<TRequest>(collection).Find<TRequest>(filters)?.ToList();

        public List<TRequest> GetDataBySorting(FilterDefinition<TRequest> filters, SortDefinition<TRequest> sortBy,
            string collection)
            => _mongoDb.GetCollection<TRequest>(collection).Find(filters)?.Sort(sortBy).ToList();

        public List<TRequest> GetTotalRecords(string collection)
        => _mongoDb.GetCollection<TRequest>(collection).Find(FilterDefinition<TRequest>.Empty).ToList();

        public long GetDocumentCount(FilterDefinition<TRequest> filters, string collectionName)
            => _mongoDb.GetCollection<TRequest>(collectionName).CountDocuments(filters);

        public void InsertMany(List<TRequest> request, string collectionName)
            => _mongoDb.GetCollection<TRequest>(collectionName).InsertMany(request);

        public void DeleteMany(FilterDefinition<TRequest> filter, string collectionName)
            => _mongoDb.GetCollection<TRequest>(collectionName).DeleteMany(filter);

        public void DeleteOne(FilterDefinition<TRequest> filter, string collectionName)
            => _mongoDb.GetCollection<TRequest>(collectionName).DeleteOne(filter);

    }
}
