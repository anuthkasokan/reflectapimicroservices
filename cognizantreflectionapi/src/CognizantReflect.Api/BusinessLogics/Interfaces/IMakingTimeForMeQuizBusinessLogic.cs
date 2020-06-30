using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IMakingTimeForMeQuizBusinessLogic
    {
        List<MakingTimeForMeQuiz> GetMakingTimeForMeQuizzes();
        int InsertMakingTimeForMeQuizzes(MakingTimeForMeQuiz makingTimeForMeQuiz);
        int InsertMakingTimeForMeQuizAttempts(List<MakingTimeForMeQuizAttempts> makingTimeForMeQuizAttempts);
    }
}
