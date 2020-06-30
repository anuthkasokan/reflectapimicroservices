using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace CognizantReflect.Api.Models.MakingTimeForMeQuiz
{
    [BsonIgnoreExtraElements]
    public class MakingTimeForMeQuiz
    {
        public int id { get; set; }
        public string question { get; set; }
        public Score scores { get; set; }
        public string updatetimestamp { get; set; }
    }
    public class Score
    {
        public int always { get; set; } //= 0;
        public int often { get; set; } //= 1;
        public int sometimes { get; set; } //= 2;
        public int rarely { get; set; } //= 3;
        public int never { get; set; } //= 4;
    }
}
