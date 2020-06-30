using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using System.Collections.Generic;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface ICulturalObservationBusinessLogic
    {
        List<CultureObservationToolQuiz> GetCulturalObservationQuiz();

        void InsertCultureObservationQuiz(
            List<CultureObservationToolQuizAttempts> cultureObservationToolQuizAttempts);
    }
}
