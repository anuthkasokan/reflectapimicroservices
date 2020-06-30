using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.ReflectionToolQuiz
{
    [BsonIgnoreExtraElements]
    public class ReflectionToolQuizAttempt
    {
        public long id { get; set; }
        public string userid { get; set; }
        public int questionid { get; set; }
        public List<string> selectedoptions { get; set; }
        public string answer { get; set; }
        public int attemptcount { get; set; }
        public string attempttimestamp { get; set; }
        public string updatetimestamp { get; set; }

    }
}
