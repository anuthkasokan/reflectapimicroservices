using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IMakingTimeForMeQuizAdapter
    {
        List<MakingTimeForMeQuiz> GetMakingTimeForMeQuizzes();

        int InsertMakingTimeForMeQuiz(MakingTimeForMeQuiz makingTimeForMeQuiz);

        int InsertMakingTimeForMeQuizAttempts(List<MakingTimeForMeQuizAttempts> makingTimeForMeQuizAttempts);

        MakingTimeForMeQuizAttempts GetLatestId();

        MakingTimeForMeQuizAttempts GetLatestAttemptByUser(string userid);
    }
}
