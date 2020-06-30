using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.ProductivityZoneQuiz
{
    [BsonIgnoreExtraElements]
    public class ProductivityZoneQuizAttempts
    {
        public int id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public string answer { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
    }
}
