using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.Models.FeedbackService
{
    public class Feedback
    {
        public long id { get; set; }
        public string userid { get; set; }
        public string question { get; set; }
        public string assigned { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string createtimestamp { get; set; }
        public string updatetimestamp { get; set; }

    }
}
