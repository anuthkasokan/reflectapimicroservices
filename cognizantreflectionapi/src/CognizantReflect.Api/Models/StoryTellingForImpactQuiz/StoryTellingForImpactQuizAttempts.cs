using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.StoryTellingForImpactQuiz
{
    [BsonIgnoreExtraElements]
    public class StoryTellingForImpactQuizAttempts
    {
        public int id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public string answer { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
    }
}
