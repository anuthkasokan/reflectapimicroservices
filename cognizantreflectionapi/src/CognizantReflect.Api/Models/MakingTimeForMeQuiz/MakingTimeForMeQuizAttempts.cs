using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.MakingTimeForMeQuiz
{
    [BsonIgnoreExtraElements]
    public class MakingTimeForMeQuizAttempts
    {
        public int id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public string answer { get; set; }
        public int score { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
    }
}
