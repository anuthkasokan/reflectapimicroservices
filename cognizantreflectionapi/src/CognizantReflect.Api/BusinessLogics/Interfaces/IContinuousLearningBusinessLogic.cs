using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IContinuousLearningBusinessLogic
    {
        List<ContinuousLearningAssessmentQuiz> GetContinuousLearningAssessmentQuizzes();
        int InsertContinuousLearningQuizResponse(List<ContinuousLearningAssessmentQuizAttempts> continuousLearningAssessmentQuizAttempts);
    }
}
