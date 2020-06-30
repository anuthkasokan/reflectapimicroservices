using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IGrowthMindsetAdapter
    {
        List<GrowthMindsetQuiz> GetGrowthMindsetQuiz();
        int InsertGrowthMindsetQuiz(GrowthMindsetQuiz growthMindsetQuiz);
        int InsertGrowthMindsetQuizAttempts(List<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts);
        GrowthMindsetQuizAttempts GetLatestId();
        GrowthMindsetQuizAttempts GetLatestAttemptByUser(string userid);
    }
}
