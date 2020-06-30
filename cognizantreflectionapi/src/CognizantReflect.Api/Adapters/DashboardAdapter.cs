using System.Collections.Generic;
using System.Linq;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Handlers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
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
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CognizantReflect.Api.Adapters
{
    internal class DashboardAdapter : IDashboardAdapter
    {

        private readonly IMongoClientHelper<CuriousQuizAttempts> _curiousQuizAttempts;
        private readonly IMongoClientHelper<BlindSpotQuizAttempts> _blindSpotQuizAttempts;
        private readonly IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts> _continuousLearningQuizAttempts;
        private readonly IMongoClientHelper<CultureObservationToolQuizAttempts> _cultureObservationToolQuizAttempts;
        private readonly IMongoClientHelper<GrowthMindsetQuizAttempts> _growthMindsetQuizAttempts;
        private readonly IMongoClientHelper<LearningMythsQuizAttempts> _learningMythsQuizAttempts;
        private readonly IMongoClientHelper<MakingTimeForMeQuizAttempts> _makingTimeForMeQuizAttempts;
        private readonly IMongoClientHelper<ProductivityZoneQuizAttempts> _productivityZoneQuizAttempts;
        private readonly IMongoClientHelper<ReflectionToolQuizAttempt> _reflectionToolQuizAttempts;
        private readonly IMongoClientHelper<StoryTellingForImpactQuizAttempts> _storyTellingForImpactQuizAttempts;

        private readonly string _curiousQuizAttemptCollection;
        private readonly string _blindSpotQuizAttemptCollection;
        private readonly string _continuousLearningQuizAttemptCollection;
        private readonly string _cultureObservationQuizAttemptCollection;
        private readonly string _growthMindsetQuizAttemptCollection;
        private readonly string _learningMythsQuizAttemptCollection;
        private readonly string _makingTimeForMeAttemptCollection;
        private readonly string _productivityZoneQuizAttemptCollection;
        private readonly string _reflectionToolQuizAttemptCollection;
        private readonly string _storyTellingForImpactAttemptQuizCollection;

        public DashboardAdapter(IMongoClientHelper<CuriousQuizAttempts> curiousQuizAttempts, IMongoClientHelper<BlindSpotQuizAttempts> blindSpotQuizAttempts,
            IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts> continuousLearningQuizAttempts, IMongoClientHelper<CultureObservationToolQuizAttempts> cultureObservationToolQuizAttempts,
            IMongoClientHelper<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts, IMongoClientHelper<LearningMythsQuizAttempts> learningMythsQuizAttempts,
            IMongoClientHelper<MakingTimeForMeQuizAttempts> makingTimeForMeQuizAttempts, IMongoClientHelper<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts,
            IMongoClientHelper<ReflectionToolQuizAttempt> reflectionToolQuizAttempts, IMongoClientHelper<StoryTellingForImpactQuizAttempts> storyTellingForImpactQuizAttempts,
            IOptions<MongoDbSettings> settings)
        {
            _curiousQuizAttempts = curiousQuizAttempts;
            _blindSpotQuizAttempts = blindSpotQuizAttempts;
            _continuousLearningQuizAttempts = continuousLearningQuizAttempts;
            _cultureObservationToolQuizAttempts = cultureObservationToolQuizAttempts;
            _growthMindsetQuizAttempts = growthMindsetQuizAttempts;
            _learningMythsQuizAttempts = learningMythsQuizAttempts;
            _makingTimeForMeQuizAttempts = makingTimeForMeQuizAttempts;
            _productivityZoneQuizAttempts = productivityZoneQuizAttempts;
            _reflectionToolQuizAttempts = reflectionToolQuizAttempts;
            _storyTellingForImpactQuizAttempts = storyTellingForImpactQuizAttempts;
            _curiousQuizAttemptCollection = settings.Value.CuriousQuizAttemptsCollection;
            _blindSpotQuizAttemptCollection = settings.Value.BlindSpotQuizAttemptsCollection;
            _continuousLearningQuizAttemptCollection = settings.Value.ContinuousLearningAssessmentQuizAttemptsCollection;
            _cultureObservationQuizAttemptCollection = settings.Value.CultureObservationToolQuizAttemptsCollection;
            _growthMindsetQuizAttemptCollection = settings.Value.GrowthMindsetAttemptsQuizCollection;
            _learningMythsQuizAttemptCollection = settings.Value.LearningMythsQuizAttemptsCollection;
            _makingTimeForMeAttemptCollection = settings.Value.MakingTimeForMeQuizAttemptsCollection;
            _productivityZoneQuizAttemptCollection = settings.Value.ProductivityZoneQuizAttemptsCollection;
            _reflectionToolQuizAttemptCollection = settings.Value.ReflectionToolQuizAttemptsCollection;
            _storyTellingForImpactAttemptQuizCollection = settings.Value.StoryTellingForImpactQuizAttemptsCollection;

        }

        public int GetAttemptCountForCuriousQuiz(string userid)
        {

            var result = _curiousQuizAttempts.GetData(FilterDefinitionHandler.FilterCuriosityByUserId(userid),
                 _curiousQuizAttemptCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }

        public int GetAttemptCountForGrowthMindsetQuiz(string userid)
        {

            var result = _growthMindsetQuizAttempts.GetData(FilterDefinitionHandler.FilterGrowthMindsetByUserId(userid),
                _growthMindsetQuizAttemptCollection).OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }

        public int GetAttemptCountForMakingTimeQuiz(string userid)
        {

            var result = _makingTimeForMeQuizAttempts.GetData(FilterDefinitionHandler.FilterMakingTimeQuizByUserId(userid),
                _makingTimeForMeAttemptCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }

        public int GetAttemptCountForCultureObservationQuiz(string userid)
        {


            var result = _cultureObservationToolQuizAttempts.GetData(FilterDefinitionHandler.FilterCultureObservationQuizByUserId(userid),
                 _cultureObservationQuizAttemptCollection).OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }

        public List<CuriousQuizAttempts> GetTotalRecordsOfCuriosityQuiz()
        {

            return _curiousQuizAttempts.GetData(FilterDefinition<CuriousQuizAttempts>.Empty, _curiousQuizAttemptCollection);

        }

        public List<GrowthMindsetQuizAttempts> GetTotalRecordsOfGrowthMindsetQuiz()
        {
            return _growthMindsetQuizAttempts.GetData(FilterDefinition<GrowthMindsetQuizAttempts>.Empty, _growthMindsetQuizAttemptCollection);

        }

        public List<MakingTimeForMeQuizAttempts> GetTotalRecordsOfMakingTimeForMeQuiz()
        {
            return _makingTimeForMeQuizAttempts.GetData(FilterDefinition<MakingTimeForMeQuizAttempts>.Empty,  _makingTimeForMeAttemptCollection);

        }

        public List<CultureObservationToolQuizAttempts> GetTotalRecordsOfCultureObservationQuiz()
        {
            return _cultureObservationToolQuizAttempts.GetData(FilterDefinition<CultureObservationToolQuizAttempts>.Empty,  _cultureObservationQuizAttemptCollection);

        }

        public List<BlindSpotQuizAttempts> GetTotalRecordsOfBlindSpotQuiz()
        {
            return _blindSpotQuizAttempts.GetData(FilterDefinition<BlindSpotQuizAttempts>.Empty,  _blindSpotQuizAttemptCollection);

        }

        public List<ContinuousLearningAssessmentQuizAttempts> GetTotalRecordsOfContinuousLearningQuiz()
        {
            return _continuousLearningQuizAttempts.GetData(FilterDefinition<ContinuousLearningAssessmentQuizAttempts>.Empty,  _continuousLearningQuizAttemptCollection);

        }

        public List<LearningMythsQuizAttempts> GetTotalRecordsOfLearningMythsQuiz()
        {
            return _learningMythsQuizAttempts.GetData(FilterDefinition<LearningMythsQuizAttempts>.Empty,  _learningMythsQuizAttemptCollection);

        }

        public List<ProductivityZoneQuizAttempts> GetTotalRecordsOfProductivityZoneQuiz()
        {
            return _productivityZoneQuizAttempts.GetData(FilterDefinition<ProductivityZoneQuizAttempts>.Empty,  _productivityZoneQuizAttemptCollection);

        }
        public List<ReflectionToolQuizAttempt> GetTotalRecordsOfReflectionToolQuiz()
        {
            return _reflectionToolQuizAttempts.GetData(FilterDefinition<ReflectionToolQuizAttempt>.Empty,  _reflectionToolQuizAttemptCollection);

        }
        public List<StoryTellingForImpactQuizAttempts> GetTotalRecordsOfStoryTellingQuiz()
        {
            return _storyTellingForImpactQuizAttempts.GetData(FilterDefinition<StoryTellingForImpactQuizAttempts>.Empty,  _storyTellingForImpactAttemptQuizCollection);

        }


        public int GetAttemptedQuizCountByUser(string userid)
        {
            var attempted= 0;



            if (_curiousQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterCuriosityByUserId(userid),
                _curiousQuizAttemptCollection) > 0)
                attempted += 1;

            if (_growthMindsetQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterGrowthMindsetByUserId(userid),
                _growthMindsetQuizAttemptCollection) > 0)
                attempted += 1;

            if (_makingTimeForMeQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterMakingTimeQuizByUserId(userid),
                _makingTimeForMeAttemptCollection) > 0)
                attempted += 1;

            if (_cultureObservationToolQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterCultureObservationQuizByUserId(userid),
                _cultureObservationQuizAttemptCollection) > 0)
                attempted += 1;

            if (_blindSpotQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterBlindSpotQuizByUserId(userid),
                _blindSpotQuizAttemptCollection) > 0)
                attempted += 1;

            if (_continuousLearningQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterContinuousLearningQuizByUserId(userid),
                _continuousLearningQuizAttemptCollection) > 0)
                attempted += 1;

            if (_learningMythsQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterLearningMythsQuizByUserId(userid),
                _learningMythsQuizAttemptCollection) > 0)
                attempted += 1;

            if (_productivityZoneQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterProductivityZoneQuizByUserId(userid),
                _productivityZoneQuizAttemptCollection) > 0)
                attempted += 1;

            if (_reflectionToolQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterReflectionToolQuizByUserId(userid),
                _reflectionToolQuizAttemptCollection) > 0)
                attempted += 1;

            if (_storyTellingForImpactQuizAttempts.GetDocumentCount(FilterDefinitionHandler.FilterStoryTellingForImpactQuizByUserId(userid),
                _storyTellingForImpactAttemptQuizCollection) > 0)
                attempted += 1;


            return attempted;
        }

        public int GetCuriousQuizScoreOfUser(string userid,int attemptCount)
        {


            return _curiousQuizAttempts.GetData(
                FilterDefinitionHandler.FilterCuriousByUseridAndAttemptCount(userid, attemptCount),
                _curiousQuizAttemptCollection).Sum(x => x.score);
        }

        public int GetGrowthMindsetQuizScoreOfUser(string userid, int attemptCount)
        {

            return _growthMindsetQuizAttempts.GetData(
                FilterDefinitionHandler.FilterGrowthMindsetByUseridAndAttemptCount(userid, attemptCount),
                _growthMindsetQuizAttemptCollection).Sum(x => x.score);
        }

        public int GetMakingTimeQuizScoreOfUser(string userid, int attemptCount)
        {
            return _makingTimeForMeQuizAttempts.GetData(
                FilterDefinitionHandler.FilterMakingTimeByUseridAndAttemptCount(userid, attemptCount),
                _makingTimeForMeAttemptCollection).Sum(x => x.score);
        }

        public int GetCultureObservationQuizScoreOfUser(string userid, int attemptCount)
        {
            return _cultureObservationToolQuizAttempts.GetData(
                FilterDefinitionHandler.FilterCultureObservationByUseridAndAttemptCount(userid, attemptCount),
                _cultureObservationQuizAttemptCollection).Sum(x => x.score);
        }

        public int GetAttemptCountForBlindSpotQuiz(string userid)
        {
            var result = _blindSpotQuizAttempts.GetData(FilterDefinitionHandler.FilterBlindSpotQuizByUserId(userid),
                _blindSpotQuizAttemptCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }

        public int GetAttemptCountForContinuousLearningQuiz(string userid)
        {
            var result = _continuousLearningQuizAttempts.GetData(FilterDefinitionHandler.FilterContinuousLearningQuizByUserId(userid),
                _continuousLearningQuizAttemptCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }
        public int GetAttemptCountForLearningMythsQuiz(string userid)
        {
            var result = _learningMythsQuizAttempts.GetData(FilterDefinitionHandler.FilterLearningMythsQuizByUserId(userid),
                 _learningMythsQuizAttemptCollection).OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }
        public int GetAttemptCountForProductivityZoneQuiz(string userid)
        {
            var result = _productivityZoneQuizAttempts.GetData(FilterDefinitionHandler.FilterProductivityZoneQuizByUserId(userid),
                 _productivityZoneQuizAttemptCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }
        public int GetAttemptCountForReflectionToolQuiz(string userid)
        {
            var result = _reflectionToolQuizAttempts.GetData(FilterDefinitionHandler.FilterReflectionToolQuizByUserId(userid),
                 _reflectionToolQuizAttemptCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }
        public int GetAttemptCountForStoryTellingForImpactQuiz(string userid)
        {
            var result = _storyTellingForImpactQuizAttempts.GetData(FilterDefinitionHandler.FilterStoryTellingForImpactQuizByUserId(userid),
                 _storyTellingForImpactAttemptQuizCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result != null && result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }

        public int GetContinuousLearningYesCount(string userid)
        {
            return _continuousLearningQuizAttempts.GetData(
                FilterDefinitionHandler.FilterContinuousLearningByUseridAndYes(userid),
                _continuousLearningQuizAttemptCollection).Count;
        }

        public int GetContinuousLearningYesCount()
        {

            return _continuousLearningQuizAttempts.GetData(
                FilterDefinitionHandler.FilterContinuousLearningByYes(),
                _continuousLearningQuizAttemptCollection).Count;
        }


        public int GetContinuousLearningNoCount(string userid)
        {

            return _continuousLearningQuizAttempts.GetData(
                FilterDefinitionHandler.FilterContinuousLearningByUseridAndNo(userid),
                _continuousLearningQuizAttemptCollection).Count;
        }

        public int GetContinuousLearningNoCount()
        {
            return _continuousLearningQuizAttempts.GetData(
                FilterDefinitionHandler.FilterContinuousLearningByNo(),
                _continuousLearningQuizAttemptCollection).Count;
        }


        public int GetContinuousLearningSomewhatCount(string userid)
        {
            return _continuousLearningQuizAttempts.GetData(
                FilterDefinitionHandler.FilterContinuousLearningBySomewhat(),
                _continuousLearningQuizAttemptCollection).Count;
        }

        public int GetContinuousLearningSomewhatCount()
        {
            return _continuousLearningQuizAttempts.GetData(
                FilterDefinitionHandler.FilterContinuousLearningBySomewhat(),
                _continuousLearningQuizAttemptCollection).Count;
        }
    }
}
