using CognizantReflect.Api.Models.LearningMythsQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface ILearningMythsBusinessLogic
    {
        List<LearningMythsQuiz> GetLearningMythsQuizzes();
        int InsertLearningMythsQuizResponse(List<LearningMythsQuizAttempts> learningMythsQuizAttempts);
    }
}
