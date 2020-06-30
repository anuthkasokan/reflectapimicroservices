using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectUser.API.Models
{
    internal class MongoDbSettings
    {
        internal string ConnectionString { get; set; }
        internal string DbName { get; set; }
        internal string UsersCollection { get; set; }
        internal string ErrorLogsCollection { get; set; }



    }
}
