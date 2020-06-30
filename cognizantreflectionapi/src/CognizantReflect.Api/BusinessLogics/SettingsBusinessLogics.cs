using System;
using System.IO;
using System.Linq;
using System.Net;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Helpers.Excel.Interface;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;


namespace CognizantReflect.Api.BusinessLogics
{
    internal class SettingsBusinessLogics : ISettingsBusinessLogics
    {
        private readonly IExcelReaderExtension _excelReaderExtension;
        private readonly ISettingsAdapter _settingsAdapter;

        public SettingsBusinessLogics(IExcelReaderExtension excelReaderExtension, ISettingsAdapter settingsAdapter)
        {
            _excelReaderExtension = excelReaderExtension;
            _settingsAdapter = settingsAdapter;
        }

        public HttpStatusCode UploadExcel(string path)
        {
            return Upload(path);
        }

        protected HttpStatusCode Upload(string path)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var excelFile = new ExcelPackage(new FileInfo(path)))
                {
                    int sheetCount = excelFile.Workbook.Worksheets.Count;

                    var configuration = _excelReaderExtension.GetConfiguration(excelFile.Workbook.Worksheets[0]);
                    int sheetNumber = 1;

                    while (sheetNumber <= sheetCount-1)
                    {
                        var sheet = excelFile.Workbook.Worksheets[sheetNumber];
                        var sheetName = excelFile.Workbook.Worksheets[sheetNumber].Name;
                        var action = configuration.FirstOrDefault(x => x.SheetName == sheetName)?.Action;

                        switch (sheetName)
                        {
                            case "Curiosity":
                                var curiousQuizList = _excelReaderExtension.ReadCuriousQuiz(sheet, action);

                                if (curiousQuizList != null && curiousQuizList.Any())
                                    _settingsAdapter.InsertCuriosityQuestionList(curiousQuizList, action);

                                break;
                            case "GrowthMindset":
                                var growthMindsetList = _excelReaderExtension.ReadGrowthMindsetQuiz(sheet, action);

                                if (growthMindsetList != null && growthMindsetList.Any())
                                    _settingsAdapter.InsertGrowthMindsetQuestionList(growthMindsetList, action);

                                break;
                            case "MakingTime":
                                var makingTimeList = _excelReaderExtension.ReadMakingTimeQuiz(sheet, action);

                                if (makingTimeList != null && makingTimeList.Any())
                                    _settingsAdapter.InsertMakingTimeQuestionList(makingTimeList, action);

                                break;
                            case "Productivity":
                                var productivityList = _excelReaderExtension.ReadProductivityZoneQuiz(sheet, action);

                                if (productivityList != null && productivityList.Any())
                                    _settingsAdapter.InsertProductivityZoneQuestionList(productivityList, action);

                                break;
                            case "Continuous":
                                var continuousList = _excelReaderExtension.ReadClaQuiz(sheet, action);

                                if (continuousList != null && continuousList.Any())
                                    _settingsAdapter.InsertClaQuestionList(continuousList, action);

                                break;
                            case "StoryTelling":
                                var storyTellingList = _excelReaderExtension.ReadStoryTellingForImpactQuiz(sheet, action);

                                if (storyTellingList != null && storyTellingList.Any())
                                    _settingsAdapter.InsertStoryTellingQuestionList(storyTellingList, action);

                                break;
                            case "Reflection":
                                var reflectionList = _excelReaderExtension.ReadReflectionToolQuiz(sheet, action);

                                if (reflectionList != null && reflectionList.Any())
                                    _settingsAdapter.InsertReflectionToolQuestionList(reflectionList, action);

                                break;
                            case "BlindSpot":
                                var blindSpotList = _excelReaderExtension.ReadBlindSpotQuiz(sheet, action);

                                if (blindSpotList != null && blindSpotList.Any())
                                    _settingsAdapter.InsertBlindSpotQuestionList(blindSpotList, action);

                                break;
                            case "LearningMyths":
                                var learningMythsList = _excelReaderExtension.ReadLearningMythsQuiz(sheet, action);

                                if (learningMythsList != null && learningMythsList.Any())
                                    _settingsAdapter.InsertLearningMythsQuestionList(learningMythsList, action);

                                break;
                            case "CultureObservation":
                                var cultureObservationList = _excelReaderExtension.ReadCultureObservationQuiz(sheet, action);

                                if (cultureObservationList != null && cultureObservationList.Any())
                                    _settingsAdapter.InsertCultureObservationQuestionList(cultureObservationList, action);

                                break;
                        }


                        sheetNumber++;
                    }
                }
            

                return HttpStatusCode.OK;
            }
            catch(Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }

        }
    }
}
