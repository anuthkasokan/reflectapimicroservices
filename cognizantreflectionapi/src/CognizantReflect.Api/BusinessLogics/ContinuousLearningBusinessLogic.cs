using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class ContinuousLearningBusinessLogic : IContinuousLearningBusinessLogic
    {
        private readonly IContinuousLearningAdapter _continuousLearningAdapter;
        public ContinuousLearningBusinessLogic(IContinuousLearningAdapter continuousLearningAdapter)
        {
            _continuousLearningAdapter = continuousLearningAdapter;
        }
        public List<ContinuousLearningAssessmentQuiz> GetContinuousLearningAssessmentQuizzes()
        {
            return _continuousLearningAdapter.GetContinuousLearningAssessmentQuizzes();
        }

        public int InsertContinuousLearningQuizResponse(List<ContinuousLearningAssessmentQuizAttempts> continuousLearningAssessmentQuizAttempts)
        {
            var latestDetails = _continuousLearningAdapter.GetLatestId();
            var latestId = 0;
            var attemptId = _continuousLearningAdapter.GetLatestAttemptByUser(continuousLearningAssessmentQuizAttempts[0].userid);
            if (latestDetails != null)
            {
                latestId = latestDetails.id;
            }
            foreach (var item in continuousLearningAssessmentQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = (attemptId?.attemptcount??0) +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            return _continuousLearningAdapter.InsertContinuousLearningAssessmentQuizResponse(continuousLearningAssessmentQuizAttempts);
        }
    }
}
