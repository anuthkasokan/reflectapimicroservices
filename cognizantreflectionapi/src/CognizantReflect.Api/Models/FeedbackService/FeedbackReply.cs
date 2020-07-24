using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.Models.FeedbackService
{
    public class FeedbackReply
    {
        public long id { get; set; }
        public string userid { get; set; }
        public long feedbackid { get; set; }
        public string feedback { get; set; }
        public string createtimestamp { get; set; }
    }
}
