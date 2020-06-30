using CognizantReflect.Api.Models.CuriosityQuiz;
using System.Collections.Generic;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface ICuriousQuizBusinessLogic
    {
        List<CuriousQuiz> GetCuriousQuizzes();
        int InsertCuriousQuiz(CuriousQuiz curiousQuiz);
        int InsertCuriousQuizResponse(List<CuriousQuizAttempts> curiousQuizAttempts);
    }
}
