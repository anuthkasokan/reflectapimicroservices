

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CognizantReflect.Api.Models.ReflectionToolQuiz;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IReflectionToolAdapter
    {
        List<ReflectionTool> GetReflectionToolQuestions();

        void SaveReflectionToolQuizAttempt(List<ReflectionToolQuizAttempt> reflectionToolAttempt);

        long GetLastInsertedReflectionQuizId();

        int GetAttemptCountForReflectionToolQuiz(string userid);

        List<ReflectionToolQuizAttempt> GetReflectionToolAttempts(string userid, int attemptCount);

        ReflectionToolQuizAttempt GetLatestAttemptByUser(string userid);

        ReflectionToolQuizAttempt GetLatestAttemptId();
    }
}
