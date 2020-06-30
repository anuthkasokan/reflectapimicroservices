using Microsoft.AspNetCore.Mvc;

namespace CognizantReflect.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        // GET: api/Ping
        [HttpGet]
        public string Get()
        {
            return "Pinged successfully!";
        }

        // GET: api/Ping/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ping
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Ping/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
