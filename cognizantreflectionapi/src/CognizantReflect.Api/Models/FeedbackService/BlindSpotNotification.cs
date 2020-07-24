using System.Collections.Generic;

namespace CognizantReflect.Api.Models.FeedbackService
{
    public class BlindSpotNotification
    {
        public string userid { get; set; }
        public List<string> coworkerid { get; set; }
    }
}
