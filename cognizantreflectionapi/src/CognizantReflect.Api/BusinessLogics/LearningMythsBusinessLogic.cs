using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class LearningMythsBusinessLogic : ILearningMythsBusinessLogic
    {
        private readonly ILearningMythsAdapter _learningMythsAdapter;

        public LearningMythsBusinessLogic(ILearningMythsAdapter learningMythsAdapter)
        {
            _learningMythsAdapter = learningMythsAdapter;
        }

        public List<LearningMythsQuiz> GetLearningMythsQuizzes()
        {
            return _learningMythsAdapter.GetLearningMythsQuizzes();
        }

        public int InsertLearningMythsQuizResponse(List<LearningMythsQuizAttempts> learningMythsQuizAttempts)
        {
            var latestDetails = _learningMythsAdapter.GetLatestId();
            var latestId = 0;
            var attemptId = _learningMythsAdapter.GetLatestAttemptByUser(learningMythsQuizAttempts[0].userid);
            if (latestDetails != null)
            {
                latestId = latestDetails.id;
            }
            foreach (var item in learningMythsQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = (attemptId?.attemptcount??0) +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            return _learningMythsAdapter.InsertLearningMythQuizAttempts(learningMythsQuizAttempts);
        }
    }
}
