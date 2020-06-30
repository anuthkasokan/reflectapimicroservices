using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.ReflectionToolQuiz;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class ReflectionToolBusinessLogics : IReflectionToolBusinessLogics
    {
        private readonly IReflectionToolAdapter _reflectionToolAdapter;

        public ReflectionToolBusinessLogics(IReflectionToolAdapter reflectionToolAdapter)
        {
            _reflectionToolAdapter = reflectionToolAdapter;
        }

        public List<ReflectionTool> GetReflectionToolQuestions()
        {
            return _reflectionToolAdapter.GetReflectionToolQuestions();
        }

        public void SaveReflectionToolResponse(List<ReflectionToolQuizAttempt> attempt)
        {
            var latestDetails = _reflectionToolAdapter.GetLatestAttemptId();
            var latestId = latestDetails?.id ?? 0;
            var attemptCount = _reflectionToolAdapter.GetLatestAttemptByUser(attempt[0].userid);


            foreach (var item in attempt)
            {
                latestId++;
    
                item.id = latestId;
                item.attemptcount = (attemptCount?.attemptcount??0) + 1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            _reflectionToolAdapter.SaveReflectionToolQuizAttempt(attempt);

        }
    }
}
