using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.ReflectionToolQuiz
{
    [BsonIgnoreExtraElements]
    public class ReflectionTool
    {

        public int id { get; set; }
        public string question { get; set; }
        public string type { get; set; }
        public string[] options { get; set; }
        public string updatetimestamp { get; set; }

    }
}
