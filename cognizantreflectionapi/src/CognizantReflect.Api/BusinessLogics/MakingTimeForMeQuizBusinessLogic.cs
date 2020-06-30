using System;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using System.Collections.Generic;
using System.Globalization;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class MakingTimeForMeQuizBusinessLogic : IMakingTimeForMeQuizBusinessLogic
    {
        private readonly IMakingTimeForMeQuizAdapter _makingTimeForMeQuizAdapter;
        public MakingTimeForMeQuizBusinessLogic(IMakingTimeForMeQuizAdapter makingTimeForMeQuizAdapter)
        {
            _makingTimeForMeQuizAdapter = makingTimeForMeQuizAdapter;
        }
        public List<MakingTimeForMeQuiz> GetMakingTimeForMeQuizzes()
        {
            return _makingTimeForMeQuizAdapter.GetMakingTimeForMeQuizzes();
        }
        public int InsertMakingTimeForMeQuizAttempts(List<MakingTimeForMeQuizAttempts> makingTimeForMeQuizAttempts)
        {
            var latestDetails = _makingTimeForMeQuizAdapter.GetLatestId();
            var latestId = 0;
            var attemptId = _makingTimeForMeQuizAdapter.GetLatestAttemptByUser(makingTimeForMeQuizAttempts[0].userid);
            if (latestDetails != null)
            {
                latestId = latestDetails.id;
            }
            foreach (var item in makingTimeForMeQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = (attemptId?.attemptcount??0) +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            return _makingTimeForMeQuizAdapter.InsertMakingTimeForMeQuizAttempts(makingTimeForMeQuizAttempts);
        }

        public int InsertMakingTimeForMeQuizzes(MakingTimeForMeQuiz makingTimeForMeQuiz)
        {
            return _makingTimeForMeQuizAdapter.InsertMakingTimeForMeQuiz(makingTimeForMeQuiz);
        }
    }
}
