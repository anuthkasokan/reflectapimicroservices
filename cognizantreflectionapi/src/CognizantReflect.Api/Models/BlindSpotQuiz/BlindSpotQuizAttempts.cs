using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.BlindSpotQuiz
{
    [BsonIgnoreExtraElements]
    public class BlindSpotQuizAttempts
    {
        public long id { get; set; }
        public string userid { get; set; }
        public string[] selectedadjectives { get; set; }
        public string[] selectedcoWorkers { get; set; }
        public string status { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }

    }
}
