using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using System.Collections.Generic;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IGrowthMindsetQuizBusinessLogic
    {
        List<GrowthMindsetQuiz> GetGrowthMindsetQuizzes();
        int InsertGrowthMindsetQuiz(GrowthMindsetQuiz growthMindsetQuiz);
        int InsertGrowthMindsetQuizResponse(List<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts);
    }
}
