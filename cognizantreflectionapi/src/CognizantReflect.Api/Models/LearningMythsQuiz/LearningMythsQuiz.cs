using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.LearningMythsQuiz
{
    [BsonIgnoreExtraElements]
    public class LearningMythsQuiz
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string type { get; set; }
        public Optionss options { get; set; }
        public string updatetimestamp { get; set; }
    }

}