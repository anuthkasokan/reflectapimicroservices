using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.CuriosityQuiz
{
    [BsonIgnoreExtraElements]
    public class CuriousQuizAttempts
    {
        public int id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public bool answer { get; set; }
        public int score { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
    }
}
