using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CognizantReflect.Api.Helpers.Excel.Interface;
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

namespace CognizantReflect.Api.Helpers.Excel
{
    internal class ExcelReaderExtension : IExcelReaderExtension
    {
        public List<ExcelConfiguration> GetConfiguration(ExcelWorksheet worksheet)
        {
            List<ExcelConfiguration> configs = new List<ExcelConfiguration>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                ExcelConfiguration config = new ExcelConfiguration();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            config.Quiz = cell.Text;
                            break;
                        case 1:
                            config.SheetName = cell.Text;
                            break;
                        case 2:
                            config.Action = cell.Text;
                            break;

                    }

                    columnNumber++;
                }

                configs.Add(config);

                id++;
            }
            return configs;
        }

        public List<CuriousQuiz> ReadCuriousQuiz(ExcelWorksheet worksheet, string action)
        {
            List<CuriousQuiz> curiousQuizzes = new List<CuriousQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                CuriousQuiz question = new CuriousQuiz();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                        case 1:
                            Boolean.TryParse(cell.Text, out var result);
                            question.answer = result;
                            break;
                        case 2:
                            question.score = Convert.ToInt32(cell.Text);
                            break;

                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                curiousQuizzes.Add(question);

                id++;
            }


            return curiousQuizzes;
        }

        public List<BlindSpotQuizQuestions> ReadBlindSpotQuiz(ExcelWorksheet worksheet, string action)
        {
            List<BlindSpotQuizQuestions> blindSpotQuizzes = new List<BlindSpotQuizQuestions>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                BlindSpotQuizQuestions question = new BlindSpotQuizQuestions();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.adjectives = cell.Text.Split(',');
                            break;
                        case 1:
                            question.selectedadmaxcount = Convert.ToInt32(cell.Text);
                            break;
                        case 2:
                            question.selectedcwmaxcount = Convert.ToInt32(cell.Text);
                            break;

                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                blindSpotQuizzes.Add(question);
                id++;
            }

            return blindSpotQuizzes;
        }

        public List<ContinuousLearningAssessmentQuiz> ReadClaQuiz(ExcelWorksheet worksheet, string action)
        {
            List<ContinuousLearningAssessmentQuiz> claQuizzes = new List<ContinuousLearningAssessmentQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                ContinuousLearningAssessmentQuiz question = new ContinuousLearningAssessmentQuiz();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                claQuizzes.Add(question);
                id++;
            }

            return claQuizzes;
        }

        public List<CultureObservationToolQuiz> ReadCultureObservationQuiz(ExcelWorksheet worksheet, string action)
        {
            List<CultureObservationToolQuiz> cultureObservationQuizzes = new List<CultureObservationToolQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                CultureObservationToolQuiz question = new CultureObservationToolQuiz();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                cultureObservationQuizzes.Add(question);
                id++;
            }

            return cultureObservationQuizzes;
        }

        public List<GrowthMindsetQuiz> ReadGrowthMindsetQuiz(ExcelWorksheet worksheet, string action)
        {
            List<GrowthMindsetQuiz> growthMindsetQuizzes = new List<GrowthMindsetQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                GrowthMindsetQuiz question = new GrowthMindsetQuiz();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                        case 1:
                            Boolean.TryParse(cell.Text, out var result);
                            question.answer = result;
                            break;
                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                growthMindsetQuizzes.Add(question);
                id++;
            }

            return growthMindsetQuizzes;
        }

        public List<LearningMythsQuiz> ReadLearningMythsQuiz(ExcelWorksheet worksheet, string action)
        {
            List<LearningMythsQuiz> learningMythsQuizzes = new List<LearningMythsQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                LearningMythsQuiz question = new LearningMythsQuiz {options = new Optionss()};

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                        case 1:
                            question.answer = cell.Text;
                            break;
                        case 2:
                            question.type = cell.Text;
                            break;
                        case 3:
                            question.options.a = cell.Text;
                            break;
                        case 4:
                            question.options.b = cell.Text;
                            break;
                        case 5:
                            question.options.c = cell.Text;
                            break;
                        case 6:
                            question.options.d = cell.Text;

                            break;

                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                learningMythsQuizzes.Add(question);
                id++;
            }

            return learningMythsQuizzes;
        }

        public List<MakingTimeForMeQuiz> ReadMakingTimeQuiz(ExcelWorksheet worksheet, string action)
        {
            List<MakingTimeForMeQuiz> makingTimeQuizzes = new List<MakingTimeForMeQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                MakingTimeForMeQuiz question = new MakingTimeForMeQuiz {scores = new Score()};

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                        case 1:
                            question.scores.always = Convert.ToInt32(cell.Text?.Trim());
                            break;
                        case 2:
                            question.scores.often = Convert.ToInt32(cell.Text?.Trim());
                            break;
                        case 3:
                            question.scores.sometimes = Convert.ToInt32(cell.Text?.Trim());
                            break;
                        case 4:
                            question.scores.rarely = Convert.ToInt32(cell.Text?.Trim());
                            break;
                        case 5:
                            question.scores.never = Convert.ToInt32(cell.Text?.Trim());
                            break;

                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                makingTimeQuizzes.Add(question);
                id++;
            }

            return makingTimeQuizzes;
        }

        public List<ProductivityZoneQuiz> ReadProductivityZoneQuiz(ExcelWorksheet worksheet, string action)
        {
            List<ProductivityZoneQuiz> productivityZoneQuizzes = new List<ProductivityZoneQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                ProductivityZoneQuiz question = new ProductivityZoneQuiz();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;

                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                productivityZoneQuizzes.Add(question);
                id++;
            }

            return productivityZoneQuizzes;
        }

        public List<ReflectionTool> ReadReflectionToolQuiz(ExcelWorksheet worksheet, string action)
        {
            List<ReflectionTool> reflectionToolsQuizzes = new List<ReflectionTool>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                ReflectionTool question = new ReflectionTool();

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                        case 1:
                            question.type = cell.Text;
                            break;
                        case 2:
                            question.options = cell.Text?.Split(",");
                            break;

                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                reflectionToolsQuizzes.Add(question);
                id++;
            }

            return reflectionToolsQuizzes;
        }

        public List<StoryTellingForImpactQuiz> ReadStoryTellingForImpactQuiz(ExcelWorksheet worksheet, string action)
        {
            List<StoryTellingForImpactQuiz> storyTellingForImpactQuizzes = new List<StoryTellingForImpactQuiz>();
            var id = 1;
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                StoryTellingForImpactQuiz question = new StoryTellingForImpactQuiz {options = new Optionss()};

                var columnNumber = 0;
                foreach (var cell in row)
                {
                    switch (columnNumber)
                    {
                        case 0:
                            question.question = cell.Text;
                            break;
                        case 1:
                            question.statement = cell.Text;
                            break;
                        case 2:
                            question.type = cell.Text;
                            break;
                        case 3:
                            question.options.a = cell.Text;
                            break;
                        case 4:
                            question.options.b = cell.Text;
                            break;
                        case 5:
                            question.options.c = cell.Text;
                            break;
                        case 6:
                            question.options.d = cell.Text;
                            break;


                    }

                    columnNumber++;
                }

                question.id = id;
                question.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                storyTellingForImpactQuizzes.Add(question);
                id++;
            }

            return storyTellingForImpactQuizzes;
        }

    }
}
