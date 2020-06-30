using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReflectionFeedback.Api.BusinessLogics.Interfaces;
using ReflectionFeedback.Api.Helpers;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IFeedbackBusinessLogics _feedbackBusinessLogics;
        public PingController(IFeedbackBusinessLogics feedbackBusinessLogics)
        {
            _feedbackBusinessLogics = feedbackBusinessLogics;
        }
        // GET: api/Ping
        [HttpGet]
        public string Get()
        {
            return "pinged successfully!";
        }

        [HttpGet("fillData", Name = "FillData")]
        public string FillData()
        {
            _feedbackBusinessLogics.FillFeedback();
            return "success";
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
