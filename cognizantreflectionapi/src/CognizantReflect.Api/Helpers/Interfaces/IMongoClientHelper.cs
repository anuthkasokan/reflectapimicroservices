using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CognizantReflect.Api.Helpers.Interfaces
{
    internal interface IMongoClientHelper<TRequest>
    {
        void InsertOne(TRequest request, string collection);

        void InsertAll(List<TRequest> request, string collection);

        void Delete(FilterDefinition<TRequest> filter, string collection);

        void UpdateOne(UpdateDefinition<TRequest> update, FilterDefinition<TRequest> filter, string collection);

        List<TRequest> GetData(FilterDefinition<TRequest> filters, string collection);

        List<TRequest> GetDataBySorting(FilterDefinition<TRequest> filters, SortDefinition<TRequest> sortBy,
            string collection);

        List<BsonDocument> GetTotalRecords(string collection);

        long GetDocumentCount(FilterDefinition<TRequest> filters, string collectionName);
        BsonDocument GetSingleRecord(string collection, FilterDefinition<BsonDocument> filter);
        List<BsonDocument> GetRecords(string collection, FilterDefinition<BsonDocument> filter);
        TRequest GetLatestId(string collectionName, SortDefinition<TRequest> sortBy);
    }
}
