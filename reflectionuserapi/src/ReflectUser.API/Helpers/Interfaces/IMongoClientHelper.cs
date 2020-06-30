using MongoDB.Driver;
using System.Collections.Generic;

namespace ReflectUser.API.Helpers.Interfaces
{
    internal interface IMongoClientHelper<TRequest>
    {
        void InsertOne(TRequest request, string collection);

        List<TRequest> GetUserDataById(FilterDefinition<TRequest> filters, string collection);

        List<TRequest> GetUserData(string collection);

        void InsertMany(List<TRequest> request, string collectionName);
    }
}
