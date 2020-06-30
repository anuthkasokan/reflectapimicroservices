using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
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
    internal class SettingsAdapter:ISettingsAdapter
    {
        private readonly IMongoClientHelper<CuriousQuiz> _curiousQuiz;
        private readonly IMongoClientHelper<BlindSpotQuizQuestions> _blindSpotQuiz;
        private readonly IMongoClientHelper<ContinuousLearningAssessmentQuiz> _continuousLearningQuiz;
        private readonly IMongoClientHelper<CultureObservationToolQuiz> _cultureObservationToolQuiz;
        private readonly IMongoClientHelper<GrowthMindsetQuiz> _growthMindsetQuiz;
        private readonly IMongoClientHelper<LearningMythsQuiz> _learningMythsQuiz;
        private readonly IMongoClientHelper<MakingTimeForMeQuiz> _makingTimeForMeQuiz;
        private readonly IMongoClientHelper<ProductivityZoneQuiz> _productivityZoneQuiz;
        private readonly IMongoClientHelper<ReflectionTool> _reflectionToolQuiz;
        private readonly IMongoClientHelper<StoryTellingForImpactQuiz> _storyTellingForImpactQuiz;


        private readonly string _curiousQuizCollection;
        private readonly string _blindSpotQuizCollection;
        private readonly string _continuousLearningQuizCollection;
        private readonly string _cultureObservationQuizCollection;
        private readonly string _growthMindsetQuizCollection;
        private readonly string _learningMythsQuizCollection;
        private readonly string _makingTimeForMeCollection;
        private readonly string _productivityZoneQuizCollection;
        private readonly string _reflectionToolQuizCollection;
        private readonly string _storyTellingForImpactQuizCollection;

        public SettingsAdapter(IMongoClientHelper<CuriousQuiz> curiousQuiz, IMongoClientHelper<BlindSpotQuizQuestions> blindSpotQuiz,
           IMongoClientHelper<ContinuousLearningAssessmentQuiz> continuousLearningQuiz, IMongoClientHelper<CultureObservationToolQuiz> cultureObservationToolQuiz,
           IMongoClientHelper<GrowthMindsetQuiz> growthMindsetQuiz, IMongoClientHelper<LearningMythsQuiz> learningMythsQuiz,
           IMongoClientHelper<MakingTimeForMeQuiz> makingTimeForMeQuiz, IMongoClientHelper<ProductivityZoneQuiz> productivityZoneQuiz,
           IMongoClientHelper<ReflectionTool> reflectionToolQuiz, IMongoClientHelper<StoryTellingForImpactQuiz> storyTellingForImpactQuiz,
           IOptions<MongoDbSettings> settings)
        {
            _curiousQuiz = curiousQuiz;
            _blindSpotQuiz = blindSpotQuiz;
            _continuousLearningQuiz = continuousLearningQuiz;
            _cultureObservationToolQuiz = cultureObservationToolQuiz;
            _growthMindsetQuiz = growthMindsetQuiz;
            _learningMythsQuiz = learningMythsQuiz;
            _makingTimeForMeQuiz = makingTimeForMeQuiz;
            _productivityZoneQuiz = productivityZoneQuiz;
            _reflectionToolQuiz = reflectionToolQuiz;
            _storyTellingForImpactQuiz = storyTellingForImpactQuiz;
            _curiousQuizCollection = settings.Value.CuriousQuizCollection;
            _blindSpotQuizCollection = settings.Value.BlindSpotQuizCollection;
            _continuousLearningQuizCollection = settings.Value.ContinuousLearningAssessmentQuizCollection;
            _cultureObservationQuizCollection = settings.Value.CultureObservationToolQuizCollection;
            _growthMindsetQuizCollection = settings.Value.GrowthMindsetQuizCollection;
            _learningMythsQuizCollection = settings.Value.LearningMythsQuizCollection;
            _makingTimeForMeCollection = settings.Value.MakingTimeForMeQuizCollection;
            _productivityZoneQuizCollection = settings.Value.ProductivityZoneQuizCollection;
            _reflectionToolQuizCollection = settings.Value.ReflectionToolQuizCollection;
            _storyTellingForImpactQuizCollection = settings.Value.StoryTellingForImpactQuizCollection;

        }

        public void InsertCuriosityQuestionList(List<CuriousQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _curiousQuiz.InsertAll(questionList,_curiousQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _curiousQuiz.Delete(FilterDefinition<CuriousQuiz>.Empty, _curiousQuizCollection);
                _curiousQuiz.InsertAll(questionList,_curiousQuizCollection);
            }
        }
        public void InsertBlindSpotQuestionList(List<BlindSpotQuizQuestions> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _blindSpotQuiz.InsertAll(questionList, _blindSpotQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _blindSpotQuiz.Delete(FilterDefinition<BlindSpotQuizQuestions>.Empty, _blindSpotQuizCollection);
                _blindSpotQuiz.InsertAll(questionList, _blindSpotQuizCollection);
            }
        }
        public void InsertClaQuestionList(List<ContinuousLearningAssessmentQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _continuousLearningQuiz.InsertAll(questionList, _continuousLearningQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _continuousLearningQuiz.Delete(FilterDefinition<ContinuousLearningAssessmentQuiz>.Empty, _continuousLearningQuizCollection);
                _continuousLearningQuiz.InsertAll(questionList, _continuousLearningQuizCollection);
            }
        }
        public void InsertCultureObservationQuestionList(List<CultureObservationToolQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _cultureObservationToolQuiz.InsertAll(questionList, _continuousLearningQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _cultureObservationToolQuiz.Delete(FilterDefinition<CultureObservationToolQuiz>.Empty, _cultureObservationQuizCollection);
                _cultureObservationToolQuiz.InsertAll(questionList, _cultureObservationQuizCollection);
            }
        }
        public void InsertGrowthMindsetQuestionList(List<GrowthMindsetQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _growthMindsetQuiz.InsertAll(questionList, _growthMindsetQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _growthMindsetQuiz.Delete(FilterDefinition<GrowthMindsetQuiz>.Empty, _growthMindsetQuizCollection);
                _growthMindsetQuiz.InsertAll(questionList, _growthMindsetQuizCollection);
            }
        }
        public void InsertLearningMythsQuestionList(List<LearningMythsQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _learningMythsQuiz.InsertAll(questionList, _learningMythsQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _learningMythsQuiz.Delete(FilterDefinition<LearningMythsQuiz>.Empty, _learningMythsQuizCollection);
                _learningMythsQuiz.InsertAll(questionList, _learningMythsQuizCollection);
            }
        }
        public void InsertMakingTimeQuestionList(List<MakingTimeForMeQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _makingTimeForMeQuiz.InsertAll(questionList, _makingTimeForMeCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _makingTimeForMeQuiz.Delete(FilterDefinition<MakingTimeForMeQuiz>.Empty, _makingTimeForMeCollection);
                _makingTimeForMeQuiz.InsertAll(questionList, _makingTimeForMeCollection);
            }
        }
        public void InsertProductivityZoneQuestionList(List<ProductivityZoneQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _productivityZoneQuiz.InsertAll(questionList, _productivityZoneQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _productivityZoneQuiz.Delete(FilterDefinition<ProductivityZoneQuiz>.Empty, _productivityZoneQuizCollection);
                _productivityZoneQuiz.InsertAll(questionList, _productivityZoneQuizCollection);
            }
        }
        public void InsertReflectionToolQuestionList(List<ReflectionTool> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _reflectionToolQuiz.InsertAll(questionList, _reflectionToolQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _reflectionToolQuiz.Delete(FilterDefinition<ReflectionTool>.Empty, _reflectionToolQuizCollection);
                _reflectionToolQuiz.InsertAll(questionList, _reflectionToolQuizCollection);
            }
        }
        public void InsertStoryTellingQuestionList(List<StoryTellingForImpactQuiz> questionList, string action)
        {
            if (action.ToLower() == "add")
            {
                _storyTellingForImpactQuiz.InsertAll(questionList, _storyTellingForImpactQuizCollection);
            }
            else if (action.ToLower() == "replace")
            {
                _storyTellingForImpactQuiz.Delete(FilterDefinition<StoryTellingForImpactQuiz>.Empty, _storyTellingForImpactQuizCollection);
                _storyTellingForImpactQuiz.InsertAll(questionList, _storyTellingForImpactQuizCollection);
            }
        }
    }
}
