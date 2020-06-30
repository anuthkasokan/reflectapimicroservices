using System;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using System.Collections.Generic;
using System.Globalization;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class CulturalObservationBusinessLogic : ICulturalObservationBusinessLogic
    {
        private readonly ICulturalObservationAdapter _cultureObservationAdapter;

        public CulturalObservationBusinessLogic(ICulturalObservationAdapter cultureObservationAdapter)
        {
            _cultureObservationAdapter = cultureObservationAdapter;
        }

        public List<CultureObservationToolQuiz> GetCulturalObservationQuiz()
        {
            return _cultureObservationAdapter.GetCutlturalObservationQuiz();
        }

        public void InsertCultureObservationQuiz(
            List<CultureObservationToolQuizAttempts> cultureObservationToolQuizAttempts)
        {
            var latestDetails = _cultureObservationAdapter.GetLatestAttemptId();
            var latestId = 0;
            var attemptId = _cultureObservationAdapter.GetLatestAttemptByUser(cultureObservationToolQuizAttempts[0].userid);
            if (latestDetails != null)
            {
                latestId = latestDetails.id;

            }
            foreach (var item in cultureObservationToolQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = (attemptId?.attemptcount??0) +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }

            _cultureObservationAdapter.InsertCultureObservationAttempt(cultureObservationToolQuizAttempts);
        }
    }
}
