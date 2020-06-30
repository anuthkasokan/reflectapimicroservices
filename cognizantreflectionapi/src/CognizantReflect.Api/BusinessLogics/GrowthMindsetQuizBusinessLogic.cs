using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class GrowthMindsetQuizBusinessLogic : IGrowthMindsetQuizBusinessLogic
    {
        private readonly IGrowthMindsetAdapter _growthMindsetAdapter;
        public GrowthMindsetQuizBusinessLogic(IGrowthMindsetAdapter growthMindsetAdapter)
        {
            _growthMindsetAdapter = growthMindsetAdapter;
        }
        public List<GrowthMindsetQuiz> GetGrowthMindsetQuizzes()
        {
            return _growthMindsetAdapter.GetGrowthMindsetQuiz();
        }

        public int InsertGrowthMindsetQuiz(GrowthMindsetQuiz growthMindsetQuiz)
        {
            return _growthMindsetAdapter.InsertGrowthMindsetQuiz(growthMindsetQuiz);
        }

        public int InsertGrowthMindsetQuizResponse(List<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts)
        {
            var latestDetails = _growthMindsetAdapter.GetLatestId();
            var latestId = 0;
            var attemptId = _growthMindsetAdapter.GetLatestAttemptByUser(growthMindsetQuizAttempts[0].userid);

            if (latestDetails != null)
            {
                latestId = latestDetails.id;
            }
            foreach (var item in growthMindsetQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = (attemptId?.attemptcount??0) +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            return _growthMindsetAdapter.InsertGrowthMindsetQuizAttempts(growthMindsetQuizAttempts);
        }
    }
}
