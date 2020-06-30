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
    internal static class FilterDefinitionHandler
    {
        internal static FilterDefinition<CuriousQuizAttempts> FilterCuriosityByUserId(string userid)
         => Builders<CuriousQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<GrowthMindsetQuizAttempts> FilterGrowthMindsetByUserId(string userid)
            => Builders<GrowthMindsetQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<MakingTimeForMeQuizAttempts> FilterMakingTimeQuizByUserId(string userid)
            => Builders<MakingTimeForMeQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<CultureObservationToolQuizAttempts> FilterCultureObservationQuizByUserId(string userid)
            => Builders<CultureObservationToolQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<BlindSpotQuizAttempts> FilterBlindSpotQuizByUserId(string userid)
            => Builders<BlindSpotQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<LearningMythsQuizAttempts> FilterLearningMythsQuizByUserId(string userid)
            => Builders<LearningMythsQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<ContinuousLearningAssessmentQuizAttempts> FilterContinuousLearningQuizByUserId(string userid)
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<ProductivityZoneQuizAttempts> FilterProductivityZoneQuizByUserId(string userid)
            => Builders<ProductivityZoneQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<ReflectionToolQuizAttempt> FilterReflectionToolQuizByUserId(string userid)
            => Builders<ReflectionToolQuizAttempt>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<StoryTellingForImpactQuizAttempts> FilterStoryTellingForImpactQuizByUserId(string userid)
            => Builders<StoryTellingForImpactQuizAttempts>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<CuriousQuizAttempts> FilterCuriosityByAttemptCount(int attemptCount)
            => Builders<CuriousQuizAttempts>.Filter.Eq(f => f.attemptcount, attemptCount);

        internal static FilterDefinition<GrowthMindsetQuizAttempts> FilterGrowthMindsetByAttemptCount(int attemptCount)
            => Builders<GrowthMindsetQuizAttempts>.Filter.Eq(f => f.attemptcount, attemptCount);

        internal static FilterDefinition<MakingTimeForMeQuizAttempts> FilterMakingTImeByAttemptCount(int attemptCount)
            => Builders<MakingTimeForMeQuizAttempts>.Filter.Eq(f => f.attemptcount, attemptCount);

        internal static FilterDefinition<CultureObservationToolQuizAttempts> FilterCultureObservationByAttemptCount(int attemptCount)
            => Builders<CultureObservationToolQuizAttempts>.Filter.Eq(f => f.attemptcount, attemptCount);

        internal static FilterDefinition<CuriousQuizAttempts> FilterCuriousByUseridAndAttemptCount(string userid,
            int attemptCount)
            => Builders<CuriousQuizAttempts>.Filter.And(FilterCuriosityByUserId(userid),
                FilterCuriosityByAttemptCount(attemptCount));

        internal static FilterDefinition<GrowthMindsetQuizAttempts> FilterGrowthMindsetByUseridAndAttemptCount(string userid,
            int attemptCount)
            => Builders<GrowthMindsetQuizAttempts>.Filter.And(FilterGrowthMindsetByUserId(userid),
                FilterGrowthMindsetByAttemptCount(attemptCount));

        internal static FilterDefinition<MakingTimeForMeQuizAttempts> FilterMakingTimeByUseridAndAttemptCount(string userid,
            int attemptCount)
            => Builders<MakingTimeForMeQuizAttempts>.Filter.And(FilterMakingTimeQuizByUserId(userid),
                FilterMakingTImeByAttemptCount(attemptCount));

        internal static FilterDefinition<CultureObservationToolQuizAttempts> FilterCultureObservationByUseridAndAttemptCount(string userid,
            int attemptCount)
            => Builders<CultureObservationToolQuizAttempts>.Filter.And(FilterCultureObservationQuizByUserId(userid),
                FilterCultureObservationByAttemptCount(attemptCount));

        internal static FilterDefinition<ContinuousLearningAssessmentQuizAttempts> FilterContinuousLearningByYes()
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.Eq(f => f.yes, true);

        internal static FilterDefinition<ContinuousLearningAssessmentQuizAttempts> FilterContinuousLearningByNo()
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.Eq(f => f.no, true);

        internal static FilterDefinition<ContinuousLearningAssessmentQuizAttempts> FilterContinuousLearningBySomewhat()
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.Eq(f => f.somewhat, true);

        internal static FilterDefinition<ContinuousLearningAssessmentQuizAttempts> FilterContinuousLearningByUseridAndYes(string userid)
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.And(FilterContinuousLearningQuizByUserId(userid),
                FilterContinuousLearningByYes());

        internal static FilterDefinition<ContinuousLearningAssessmentQuizAttempts> FilterContinuousLearningByUseridAndNo(string userid)
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.And(FilterContinuousLearningQuizByUserId(userid),
                FilterContinuousLearningByNo());

        internal static FilterDefinition<ContinuousLearningAssessmentQuizAttempts> FilterContinuousLearningByUseridAndSomewhat(string userid)
            => Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.And(FilterContinuousLearningQuizByUserId(userid),
                FilterContinuousLearningBySomewhat());

        internal static FilterDefinition<BlindSpotCoWorkerReply> FilterCoWorkerResponsesByAttemptId(long attemptId)
            => Builders<BlindSpotCoWorkerReply>.Filter.Eq(f => f.attemptid, attemptId);

        internal static FilterDefinition<BlindSpotCoWorkerReply> FilterCoWorkerResponsesByReplyId(long replyId)
            => Builders<BlindSpotCoWorkerReply>.Filter.Eq(f => f.id, replyId);

        internal static FilterDefinition<BlindSpotCoWorkerReply> FilterPendingCoWorkerReplies(string userid)
            => Builders<BlindSpotCoWorkerReply>.Filter.And(
                Builders<BlindSpotCoWorkerReply>.Filter.Eq(x => x.userid, userid),
                Builders<BlindSpotCoWorkerReply>.Filter.Eq(x => x.selectedadjectives, new string[] { }));

        internal static FilterDefinition<ReflectionToolQuizAttempt> FilterReflectionToolByAttemptCount(int attemptCount)
            => Builders<ReflectionToolQuizAttempt>.Filter.Eq(f => f.attemptcount, attemptCount);

        internal static FilterDefinition<ReflectionToolQuizAttempt> FilterReflectionByUserAndAttemptCount(string userid,int attemptCount)
            => Builders<ReflectionToolQuizAttempt>.Filter.And(FilterReflectionToolQuizByUserId(userid),FilterReflectionToolByAttemptCount(attemptCount));
    }
}