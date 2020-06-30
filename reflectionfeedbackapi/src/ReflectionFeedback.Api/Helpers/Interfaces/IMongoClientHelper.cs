using MongoDB.Driver;
using System.Collections.Generic;

namespace ReflectionFeedback.Api.Helpers.Interfaces
{
    internal interface IMongoClientHelper<TRequest>
    {
        void InsertOne(TRequest request, string collection);

        void UpdateOne(UpdateDefinition<TRequest> update, FilterDefinition<TRequest> filter, string collection);

        List<TRequest> GetData(FilterDefinition<TRequest> filters, string collection);

        List<TRequest> GetDataBySorting(FilterDefinition<TRequest> filters, SortDefinition<TRequest> sortBy,
            string collection);

        List<TRequest> GetTotalRecords(string collection);

        long GetDocumentCount(FilterDefinition<TRequest> filters, string collectionName);

        void InsertMany(List<TRequest> request, string collectionName);

        void DeleteMany(FilterDefinition<TRequest> filter, string collectionName);

        void DeleteOne(FilterDefinition<TRequest> filter, string collectionName);
    }
}
