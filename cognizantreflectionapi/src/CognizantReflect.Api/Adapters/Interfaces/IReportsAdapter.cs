using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IReportsAdapter
    {
        //List<QuizAttempts> GetCuriousQuizAttempts(string type);
        QuizDetails GetQuizDetails(int quizId);
        List<QuizDetails> GetAllQuizzes();
        List<QuizAttempts> GetCuriousQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetBlindSpotQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetGrowthMindsetQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetStoryTellingForImpactQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetMakingTimeForMeQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetContinuousLearningQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetLearningMythQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetCulturalObservationQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetProductivityZoneQuizAttempts(string userId, int attempt, QuizDetails quizDetails);
        List<QuizAttempts> GetReflectionToolQuizAttempts(string userId, int attempt, QuizDetails quizDetails);

    }
}
