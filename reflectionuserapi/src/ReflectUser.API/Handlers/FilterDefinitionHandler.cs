using MongoDB.Driver;
using ReflectUser.API.Models;

namespace ReflectUser.API.Handlers
{
    internal static class FilterDefinitionHandler
    {
        internal static FilterDefinition<UserDetails> FilterUserDetailsByUserId(string userid)
         => Builders<UserDetails>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<UserDetails> FilterUserDetailsByEmailId(string emailId)
         => Builders<UserDetails>.Filter.Eq(f => f.emailid, emailId);

        internal static FilterDefinition<UserDetails> FilterUserDetailsByRole(string role)
            => Builders<UserDetails>.Filter.Eq(f => f.role, role);
    }
}
