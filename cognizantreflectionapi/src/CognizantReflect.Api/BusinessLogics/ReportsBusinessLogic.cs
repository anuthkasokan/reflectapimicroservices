using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.Reports;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class ReportsBusinessLogic : IReportsBusinessLogic
    {
        private readonly IReportsAdapter _reportsAdapter;

        public ReportsBusinessLogic(IReportsAdapter reportsAdapter)
        {
            _reportsAdapter = reportsAdapter;
        }
        public List<QuizAttempts> GetQuizAttempts(string userId, int quizId, int attempt)
        {
            var quizDetails = _reportsAdapter.GetQuizDetails(quizId);

            switch (quizDetails.quizname)
            {
                case "curiosity":
                    return _reportsAdapter.GetCuriousQuizAttempts(userId, attempt, quizDetails);
                case "blindspot":
                    return _reportsAdapter.GetBlindSpotQuizAttempts(userId, attempt, quizDetails);
                case "growthmindset":
                    return _reportsAdapter.GetGrowthMindsetQuizAttempts(userId, attempt, quizDetails);
                case "makingtimeforme":
                    return _reportsAdapter.GetMakingTimeForMeQuizAttempts(userId, attempt, quizDetails);
                case "storytellingforimpact":
                    return _reportsAdapter.GetStoryTellingForImpactQuizAttempts(userId, attempt, quizDetails);
                case "continuouslearningassessment":
                    return _reportsAdapter.GetContinuousLearningQuizAttempts(userId, attempt, quizDetails);
                case "culturalobservation":
                    return _reportsAdapter.GetCulturalObservationQuizAttempts(userId, attempt, quizDetails);
                case "learningmyths":
                    return _reportsAdapter.GetLearningMythQuizAttempts(userId, attempt, quizDetails);
                case "productivityzone":
                    return _reportsAdapter.GetProductivityZoneQuizAttempts(userId, attempt, quizDetails);
                case "reflectiontool":
                    return _reportsAdapter.GetReflectionToolQuizAttempts(userId, attempt, quizDetails);
                default:
                    return new List<QuizAttempts>();

            }

        }

        public List<QuizDetails> GetQuizzes()
        {
            return _reportsAdapter.GetAllQuizzes();
        }

    }
}
