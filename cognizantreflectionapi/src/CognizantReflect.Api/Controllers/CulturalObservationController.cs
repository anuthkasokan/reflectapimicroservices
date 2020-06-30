using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using Microsoft.AspNetCore.Mvc;


namespace CognizantReflect.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CulturalObservationController : ControllerBase
    {
        private readonly ICulturalObservationBusinessLogic _culturalObservationAdapterBusinessLogic;

        public CulturalObservationController(ICulturalObservationBusinessLogic culturalObservationAdapterBusinessLogic)
        {
            _culturalObservationAdapterBusinessLogic = culturalObservationAdapterBusinessLogic;
        }

        //<CulturalObservationController>
        [HttpGet("getCulturalObservationQuiz",Name = "getCulturalObservationQuiz")]
        public List<CultureObservationToolQuiz> GetCulturalObservationQuiz()
        {
            return _culturalObservationAdapterBusinessLogic.GetCulturalObservationQuiz();
        }

        [HttpPost("saveCultureObservationAttempt", Name = "saveCultureObservationAttempt")]
        public IActionResult SaveCultureObservationAttempt(List<CultureObservationToolQuizAttempts> cultureObservationToolQuizAttempt)
        { 
            _culturalObservationAdapterBusinessLogic.InsertCultureObservationQuiz(cultureObservationToolQuizAttempt);
            return Ok();
        }

        // GET api/<CulturalObservationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CulturalObservationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CulturalObservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CulturalObservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
