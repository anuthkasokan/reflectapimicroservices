using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.ProductivityZoneQuiz
{
    [BsonIgnoreExtraElements]
    public class ProductivityZoneQuiz
    {
        public int id { get; set; }
        public string question { get; set; }
        public string updatetimestamp { get; set; }
    }
}
