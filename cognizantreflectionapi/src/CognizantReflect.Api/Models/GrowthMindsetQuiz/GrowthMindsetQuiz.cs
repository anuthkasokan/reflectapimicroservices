using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.GrowthMindsetQuiz
{
    [BsonIgnoreExtraElements]
    public class GrowthMindsetQuiz
    {
        public int id { get; set; }
        public string question { get; set; }
        public bool answer { get; set; }
        public string updatetimestamp { get; set; }
    }
}
