using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.BlindSpotQuiz
{
    [BsonIgnoreExtraElements]
    public class BlindSpotQuizQuestions
    {
        public int id { get; set; }
        public string[] adjectives { get; set; }
        public int selectedcwmaxcount { get; set; }
        public int selectedadmaxcount { get; set; }
        public string updatetimestamp { get; set; }

    }
}
