using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IStoryTellingForImpactAdapter
    {
        List<StoryTellingForImpactQuiz> GetStoryTellingForImpactQuizzes();

        int InsertStoryTellingForImpactQuizzes(StoryTellingForImpactQuiz storyTellingForImpactQuiz);

        int InsertStoryTellingForImpactQuizzAttempts(List<StoryTellingForImpactQuizAttempts> storyTellingForImpactQuizAttempts);

        StoryTellingForImpactQuizAttempts GetLatestId();

        StoryTellingForImpactQuizAttempts GetLatestAttemptByUser(string userid);

    }
}
