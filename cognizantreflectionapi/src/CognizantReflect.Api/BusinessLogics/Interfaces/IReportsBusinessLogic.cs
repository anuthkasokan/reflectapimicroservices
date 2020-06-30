using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IReportsBusinessLogic
    {
        List<QuizAttempts> GetQuizAttempts(string userId, int quizId, int attempt);
        List<QuizDetails> GetQuizzes();
    }
}
