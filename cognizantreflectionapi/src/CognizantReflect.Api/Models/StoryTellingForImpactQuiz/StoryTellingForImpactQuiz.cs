using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.StoryTellingForImpactQuiz
{
    [BsonIgnoreExtraElements]
    public class StoryTellingForImpactQuiz
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string statement { get; set; }
        public string type { get; set; }
        public Optionss options { get; set; }
        public string updatetimestamp { get; set; }
    }

    public class Optionss
    {
        public string a { get; set; } 
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
    }
}
