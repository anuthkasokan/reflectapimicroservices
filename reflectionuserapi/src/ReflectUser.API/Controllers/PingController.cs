using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReflectUser.API.BusinessAccess.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReflectUser.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IUserDetailBusinessLogic _userDetailBusinessLogic;
        public PingController(IUserDetailBusinessLogic userDetailBusinessLogic)
        {
            _userDetailBusinessLogic = userDetailBusinessLogic;
        }

        // GET: api/<PingController>
        [HttpGet]
        public string Get()
        {
            return "Pinged successfully!";
        }


        // POST api/<PingController>
        [HttpPost("fillData",Name = "fillData")]
        public void Post()
        {
            _userDetailBusinessLogic.FillUserData();
        }

        // PUT api/<PingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
