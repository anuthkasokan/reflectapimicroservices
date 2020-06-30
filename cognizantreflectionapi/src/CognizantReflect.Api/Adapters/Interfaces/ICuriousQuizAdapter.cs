using CognizantReflect.Api.Models.CuriosityQuiz;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface ICuriousQuizAdapter
    {
        List<CuriousQuiz> GetCuriosQuizzes();
        int InsertCuriosQuiz(CuriousQuiz curiosQuiz);
        int InsertCuriosQuizResponse(List<CuriousQuizAttempts> curiosQuizAttempts);
        CuriousQuizAttempts GetLatestId();
        List<CuriousQuizAttempts> GetCuriousAttempts(string userid, int attemptCount);
        CuriousQuizAttempts GetLatestAttemptByUser(string userid);

    }
}
