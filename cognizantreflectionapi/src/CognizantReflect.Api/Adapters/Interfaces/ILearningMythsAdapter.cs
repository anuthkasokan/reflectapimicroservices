using CognizantReflect.Api.Models.LearningMythsQuiz;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface ILearningMythsAdapter
    {
        List<LearningMythsQuiz> GetLearningMythsQuizzes();
        int InsertLearningMythQuizAttempts(List<LearningMythsQuizAttempts> growthMindsetQuizAttempts);
        LearningMythsQuizAttempts GetLatestId();
        LearningMythsQuizAttempts GetLatestAttemptByUser(string userid);
    }
}
