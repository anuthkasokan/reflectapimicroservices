using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.CultureObservationToolQuiz
{
    [BsonIgnoreExtraElements]
    public class CultureObservationToolQuizAttempts
    {
        public int id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public string date { get; set; }
        public string meetingtitle { get; set; }
        public string scoring { get; set; }
        public int score { get; set; }
        public string comments { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
    }
}
