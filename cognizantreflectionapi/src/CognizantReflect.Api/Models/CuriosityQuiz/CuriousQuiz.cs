using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.CuriosityQuiz
{
    [BsonIgnoreExtraElements]
    public class CuriousQuiz
    {
        public int id { get; set; }
        public int quizid { get; set; }
        public string question { get; set; }
        public bool answer { get; set; }
        public int score { get; set; }
        public string updatetimestamp { get; set; }
    }
}
