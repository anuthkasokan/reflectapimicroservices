using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.Models.BlindSpotQuiz
{
    public class BlindSpotCoWorkerReply
    {
        public long id { get; set; }
        public long attemptid { get; set; }
        public string userid { get; set; }
        public string[] selectedadjectives { get; set; }
        public string replytimestamp { get; set; }

    }
}
