using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface ICulturalObservationAdapter
    {
        List<CultureObservationToolQuiz> GetCutlturalObservationQuiz();

        public void InsertCultureObservationAttempt(
            List<CultureObservationToolQuizAttempts> cultureObservationAttempts);

        public CultureObservationToolQuizAttempts GetLatestAttemptByUser(string userid);

        CultureObservationToolQuizAttempts GetLatestAttemptId();
    }
}
