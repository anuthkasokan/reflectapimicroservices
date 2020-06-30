using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IContinuousLearningAdapter
    {
        List<ContinuousLearningAssessmentQuiz> GetContinuousLearningAssessmentQuizzes();
        int InsertContinuousLearningAssessmentQuizResponse(List<ContinuousLearningAssessmentQuizAttempts> continuousLearningAssessmentQuizAttempts);
        ContinuousLearningAssessmentQuizAttempts GetLatestId();
        ContinuousLearningAssessmentQuizAttempts GetLatestAttemptByUser(string userid);
    }
}
