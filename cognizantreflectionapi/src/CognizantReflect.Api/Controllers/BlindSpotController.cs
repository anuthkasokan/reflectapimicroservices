using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CognizantReflect.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BlindSpotController : ControllerBase
    {
        private readonly IBlindSpotBusinessLogics _blindSpotBusinessLogics;

        public BlindSpotController(IBlindSpotBusinessLogics blindSpotBusinessLogics)
        {
            _blindSpotBusinessLogics = blindSpotBusinessLogics;
        }

        // GET: api/BlindSpot
        [HttpGet("getBlindSpotQuestions", Name = "GetBlindSpotQuestions")]
        public BlindSpotQuizQuestions GetBlindSpotQuestions()
        {
            return _blindSpotBusinessLogics.GetBlindSpotQuizQuestions();

        }

        // GET: api/BlindSpot/5
        [HttpGet("getBlindSpotResult/{userid}", Name = "GetBlindSpotResult")]
        public BlindSpotQuizResult GetBlindSpotResult(string userid)
        {
            return _blindSpotBusinessLogics.ShowBlindSpotQuizResult(userid);
        }

        [HttpGet("getBlindSpotReplyRequest/{userid}", Name = "GetBlindSpotReplyRequest")]
        public List<BlindSpotCoWorkerReply> GetBlindSpotReplyRequest(string userid)
        {
            return _blindSpotBusinessLogics.GetBlindSpotCoWorkerRequest(userid);
        }

        // POST: api/BlindSpot
        [HttpPost("saveUserAttempts", Name = "SaveUserAttempts")]
        public void SaveUserAttempts(BlindSpotQuizAttempts response)
        {
            _blindSpotBusinessLogics.SaveBlindSpotUserResponse(response);
        }

        // POST: api/BlindSpot
        [HttpPost("saveCoWorkerReplies", Name = "SaveCoWorkerReplies")]
        public void SaveCoWorkerReplies(BlindSpotCoWorkerReply response)
        {
            _blindSpotBusinessLogics.UpdateBlindSpotCoWorkerReply(response);
        }

        // PUT: api/BlindSpot/5
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
