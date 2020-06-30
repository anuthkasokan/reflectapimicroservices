using MongoDB.Bson;
using MongoDB.Driver;
using ReflectionEmailService.Models;
using System.Collections.Generic;

namespace CognizantReflect.Api.Helpers.Interfaces
{
    internal interface IMongoClientHelper<TRequest>
    {
        List<TRequest> GetData(string collection, string type, FilterDefinition<TRequest> filters);
        void InsertOne(TRequest request, string collection);
        BsonDocument GetRecords(string collection, string type);
        void UpdateOne(UpdateDefinition<TRequest> update, FilterDefinition<TRequest> filter, string collection);
    }
}
