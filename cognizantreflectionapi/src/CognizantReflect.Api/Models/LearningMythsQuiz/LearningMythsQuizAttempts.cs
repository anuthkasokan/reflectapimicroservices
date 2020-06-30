using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.LearningMythsQuiz
{
    [BsonIgnoreExtraElements]
    public class LearningMythsQuizAttempts
    {
        public int id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public string selectedoption { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
    }
}
