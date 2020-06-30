using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.Helpers
{
    public static class Common
    {
        public static int IntegerNullCheck(BsonValue bsonValue)
            => bsonValue == null ? 0 : Convert.ToInt32(bsonValue);

        public static string StringNullCheck(BsonValue bsonValue)
            => bsonValue == null ? "" : bsonValue.ToString();

        public static bool BooleanNullCheck(BsonValue bsonValue)
            => bsonValue == null ? true : Convert.ToBoolean(bsonValue);
    }
}
