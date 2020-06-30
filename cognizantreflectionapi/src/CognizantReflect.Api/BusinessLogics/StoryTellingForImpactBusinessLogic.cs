using System;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using System.Collections.Generic;
using System.Globalization;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class StoryTellingForImpactBusinessLogic : IStoryTellingForImpactBusinessLogic
    {
        private readonly IStoryTellingForImpactAdapter _storyTellingForImpactAdapter;
        public StoryTellingForImpactBusinessLogic(IStoryTellingForImpactAdapter storyTellingForImpactAdapter)
        {
            _storyTellingForImpactAdapter = storyTellingForImpactAdapter;
        }
        public List<StoryTellingForImpactQuiz> GetStoryTellingForImpactQuizzes()
        {
            return _storyTellingForImpactAdapter.GetStoryTellingForImpactQuizzes();
        }

        public int InsertStoryTellingForImpactQuizzAttempts(List<StoryTellingForImpactQuizAttempts> storyTellingForImpactQuizAttempts)
        {
            var latestDetails = _storyTellingForImpactAdapter.GetLatestId();
            var latestId = 0;
            var attemptId = _storyTellingForImpactAdapter.GetLatestAttemptByUser(storyTellingForImpactQuizAttempts[0].userid);

            if (latestDetails != null)
            {
                latestId = latestDetails.id;
            }
            foreach (var item in storyTellingForImpactQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = (attemptId?.attemptcount??0) +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            return _storyTellingForImpactAdapter.InsertStoryTellingForImpactQuizzAttempts(storyTellingForImpactQuizAttempts);
        }

        public int InsertStoryTellingForImpactQuizzes(StoryTellingForImpactQuiz storyTellingForImpactQuiz)
        {
            return _storyTellingForImpactAdapter.InsertStoryTellingForImpactQuizzes(storyTellingForImpactQuiz);
        }
    }
}
