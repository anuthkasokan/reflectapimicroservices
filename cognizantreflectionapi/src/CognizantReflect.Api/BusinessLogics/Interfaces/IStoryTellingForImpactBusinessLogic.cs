using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using System.Collections.Generic;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IStoryTellingForImpactBusinessLogic
    {
        List<StoryTellingForImpactQuiz> GetStoryTellingForImpactQuizzes();

        int InsertStoryTellingForImpactQuizzes(StoryTellingForImpactQuiz storyTellingForImpactQuiz);

        int InsertStoryTellingForImpactQuizzAttempts(
            List<StoryTellingForImpactQuizAttempts> storyTellingForImpactQuizAttempts);

    }
}
