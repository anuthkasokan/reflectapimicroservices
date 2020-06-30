using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionFeedback.Api.Models
{
    public class BlindSpotNotification
    {
        public string userid { get; set; }
        public List<string> coworkerid { get; set; }
    }
}
