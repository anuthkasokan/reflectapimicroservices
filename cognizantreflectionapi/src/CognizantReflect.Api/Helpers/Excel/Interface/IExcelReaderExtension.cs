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
using CognizantReflect.Api.Models.Settings;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace CognizantReflect.Api.Helpers.Excel.Interface
{
    internal interface IExcelReaderExtension
    {
        List<ExcelConfiguration> GetConfiguration(ExcelWorksheet worksheet);

        List<CuriousQuiz> ReadCuriousQuiz(ExcelWorksheet worksheet, string action);

        List<BlindSpotQuizQuestions> ReadBlindSpotQuiz(ExcelWorksheet worksheet, string action);

        List<ContinuousLearningAssessmentQuiz> ReadClaQuiz(ExcelWorksheet worksheet, string action);

        List<CultureObservationToolQuiz> ReadCultureObservationQuiz(ExcelWorksheet worksheet, string action);

        List<GrowthMindsetQuiz> ReadGrowthMindsetQuiz(ExcelWorksheet worksheet, string action);

        List<LearningMythsQuiz> ReadLearningMythsQuiz(ExcelWorksheet worksheet, string action);

        List<MakingTimeForMeQuiz> ReadMakingTimeQuiz(ExcelWorksheet worksheet, string action);

        List<ProductivityZoneQuiz> ReadProductivityZoneQuiz(ExcelWorksheet worksheet, string action);

        List<ReflectionTool> ReadReflectionToolQuiz(ExcelWorksheet worksheet, string action);

        List<StoryTellingForImpactQuiz> ReadStoryTellingForImpactQuiz(ExcelWorksheet worksheet, string action);

    }
}
