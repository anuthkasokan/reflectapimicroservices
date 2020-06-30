using System.Collections.Generic;
using CognizantReflect.Api.Models.ReflectionToolQuiz;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IReflectionToolBusinessLogics
    {
        List<ReflectionTool> GetReflectionToolQuestions();

        void SaveReflectionToolResponse(List<ReflectionToolQuizAttempt> attempt);
    }
}
