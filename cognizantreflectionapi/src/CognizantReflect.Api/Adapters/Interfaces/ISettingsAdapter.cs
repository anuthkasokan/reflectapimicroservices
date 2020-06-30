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
    internal interface ISettingsAdapter
    {
        void InsertCuriosityQuestionList(List<CuriousQuiz> questionList, string action);

        void InsertBlindSpotQuestionList(List<BlindSpotQuizQuestions> questionList, string action);

        void InsertClaQuestionList(List<ContinuousLearningAssessmentQuiz> questionList, string action);

        void InsertCultureObservationQuestionList(List<CultureObservationToolQuiz> questionList, string action);

        void InsertGrowthMindsetQuestionList(List<GrowthMindsetQuiz> questionList, string action);

        void InsertLearningMythsQuestionList(List<LearningMythsQuiz> questionList, string action);

        void InsertMakingTimeQuestionList(List<MakingTimeForMeQuiz> questionList, string action);

        void InsertProductivityZoneQuestionList(List<ProductivityZoneQuiz> questionList, string action);

        void InsertReflectionToolQuestionList(List<ReflectionTool> questionList, string action);

        void InsertStoryTellingQuestionList(List<StoryTellingForImpactQuiz> questionList, string action);

    }
}
