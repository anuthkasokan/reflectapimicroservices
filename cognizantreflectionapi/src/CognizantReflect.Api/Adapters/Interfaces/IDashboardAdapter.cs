using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using CognizantReflect.Api.Models.CuriosityQuiz;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IDashboardAdapter
    {
        int GetAttemptCountForCuriousQuiz(string userid);

        int GetAttemptCountForGrowthMindsetQuiz(string userid);

        int GetAttemptCountForMakingTimeQuiz(string userid);

        int GetAttemptCountForCultureObservationQuiz(string userid);

        List<CuriousQuizAttempts> GetTotalRecordsOfCuriosityQuiz();

        List<GrowthMindsetQuizAttempts> GetTotalRecordsOfGrowthMindsetQuiz();

        List<MakingTimeForMeQuizAttempts> GetTotalRecordsOfMakingTimeForMeQuiz();

        List<CultureObservationToolQuizAttempts> GetTotalRecordsOfCultureObservationQuiz();

        int GetAttemptedQuizCountByUser(string userid);

        int GetCuriousQuizScoreOfUser(string userid, int attemptCount);

        int GetGrowthMindsetQuizScoreOfUser(string userid, int attemptCount);

        int GetMakingTimeQuizScoreOfUser(string userid, int attemptCount);

        int GetCultureObservationQuizScoreOfUser(string userid, int attemptCount);

        int GetAttemptCountForBlindSpotQuiz(string userid);

        int GetAttemptCountForContinuousLearningQuiz(string userid);

        int GetAttemptCountForLearningMythsQuiz(string userid);

        int GetAttemptCountForProductivityZoneQuiz(string userid);

        int GetAttemptCountForReflectionToolQuiz(string userid);

        int GetAttemptCountForStoryTellingForImpactQuiz(string userid);

        List<BlindSpotQuizAttempts> GetTotalRecordsOfBlindSpotQuiz();

        List<ContinuousLearningAssessmentQuizAttempts> GetTotalRecordsOfContinuousLearningQuiz();

        List<LearningMythsQuizAttempts> GetTotalRecordsOfLearningMythsQuiz();

        List<ProductivityZoneQuizAttempts> GetTotalRecordsOfProductivityZoneQuiz();

        List<ReflectionToolQuizAttempt> GetTotalRecordsOfReflectionToolQuiz();

        List<StoryTellingForImpactQuizAttempts> GetTotalRecordsOfStoryTellingQuiz();

        int GetContinuousLearningYesCount(string userid);

        int GetContinuousLearningYesCount();

        int GetContinuousLearningNoCount(string userid);

        int GetContinuousLearningNoCount();

        int GetContinuousLearningSomewhatCount(string userid);

        int GetContinuousLearningSomewhatCount();

    }
}
