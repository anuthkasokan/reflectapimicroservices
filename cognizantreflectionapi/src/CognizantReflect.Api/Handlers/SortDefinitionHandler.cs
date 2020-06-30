using System;
using System.Collections.Generic;
using System.Linq;
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
using MongoDB.Driver;

namespace CognizantReflect.Api.Handlers
{
    internal static class SortDefinitionHandler
    {

        internal static SortDefinition<CuriousQuizAttempts> SortCuriosityQuizAttempts()
            => Builders<CuriousQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<GrowthMindsetQuizAttempts> SortGrowthMindsetAttempts()
            => Builders<GrowthMindsetQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<MakingTimeForMeQuizAttempts> SortMakingTimeQuizAttempts()
            => Builders<MakingTimeForMeQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<CultureObservationToolQuizAttempts> SortCultureObservationQuizAttempt()
            => Builders<CultureObservationToolQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<BlindSpotQuizAttempts> SortBlindSpotQuizAttempts()
            => Builders<BlindSpotQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<ContinuousLearningAssessmentQuizAttempts> SortContinuousLearningQuizAttempts()
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<LearningMythsQuizAttempts> SortLearningMythsQuizAttempts()
            => Builders<LearningMythsQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<ProductivityZoneQuizAttempts> SortProductivityZoneQuizAttempts()
            => Builders<ProductivityZoneQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<ReflectionToolQuizAttempt> SortReflectionToolQuizAttempts()
            => Builders<ReflectionToolQuizAttempt>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<StoryTellingForImpactQuizAttempts> SortStoryTellingForImpactQuizAttempts()
            => Builders<StoryTellingForImpactQuizAttempts>.Sort.Descending(f => f.attemptcount);

        internal static SortDefinition<BlindSpotQuizAttempts> SortBlindSpotAttemptDesc()
            => Builders<BlindSpotQuizAttempts>.Sort.Descending(f => f.id);

        internal static SortDefinition<BlindSpotCoWorkerReply> SortCoWorkerReplyDesc()
            => Builders<BlindSpotCoWorkerReply>.Sort.Descending(f => f.id);

        internal static SortDefinition<ReflectionToolQuizAttempt> SortReflectionToolQuizById()
            => Builders<ReflectionToolQuizAttempt>.Sort.Descending(f => f.id);
    }
}
