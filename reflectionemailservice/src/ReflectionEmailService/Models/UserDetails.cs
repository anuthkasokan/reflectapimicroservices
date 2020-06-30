using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionEmailService.Models
{
    public class UserDetails
    {
        public int id { get; set; }
        public string userid { get; set; }
        public string emailid { get; set; }
        public string role { get; set; }
        public string updatetimestamp { get; set; }
    }
}
