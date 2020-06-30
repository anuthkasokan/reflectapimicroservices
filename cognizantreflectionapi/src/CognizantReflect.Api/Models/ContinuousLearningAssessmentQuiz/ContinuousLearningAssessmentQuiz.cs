using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz
{
    [BsonIgnoreExtraElements]
    public class ContinuousLearningAssessmentQuiz
    {
        public long id { get; set; }
        public string question { get; set; }
        public string updatetimestamp { get; set; }
    }
}
