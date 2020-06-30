using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.CuriosityQuiz;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class CuriousQuizBusinessLogic : ICuriousQuizBusinessLogic
    {
        private readonly ICuriousQuizAdapter _curiousityQuizAdapter;
        public CuriousQuizBusinessLogic(ICuriousQuizAdapter curiousityQuizAdapter)
        {
            _curiousityQuizAdapter = curiousityQuizAdapter;
        }
        public List<CuriousQuiz> GetCuriousQuizzes()
        {
            return _curiousityQuizAdapter.GetCuriosQuizzes();
        }

        public int InsertCuriousQuiz(CuriousQuiz curiousQuiz)
        {
            return _curiousityQuizAdapter.InsertCuriosQuiz(curiousQuiz);
        }

        public int InsertCuriousQuizResponse(List<CuriousQuizAttempts> curiousQuizAttempts)
        {
            var latestDetails = _curiousityQuizAdapter.GetLatestId();
            var latestId = 0;
            var attemptId = _curiousityQuizAdapter.GetLatestAttemptByUser(curiousQuizAttempts[0].userid);
            if (latestDetails != null)
            {
                latestId = latestDetails.id;
            }
            foreach (var item in curiousQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = attemptId?.attemptcount ?? 0 +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            return _curiousityQuizAdapter.InsertCuriosQuizResponse(curiousQuizAttempts);
        }
    }
}
