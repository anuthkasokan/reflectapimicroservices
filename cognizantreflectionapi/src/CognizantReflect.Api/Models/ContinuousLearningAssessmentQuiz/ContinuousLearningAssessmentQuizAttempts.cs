using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz
{
    [BsonIgnoreExtraElements]
    public class ContinuousLearningAssessmentQuizAttempts
    {
        public int id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public bool yes { get; set; }
        public bool somewhat { get; set; }
        public bool no { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
    }
}
