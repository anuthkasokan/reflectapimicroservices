using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IProductivityZoneQuizBusinessLogic
    {
        List<ProductivityZoneQuiz> GetProductivityZoneQuizzes();

        void InsertProductivityZoneQuizzes(ProductivityZoneQuiz productivityZoneQuiz);

        void InsertProductivityZoneQuizAttempts(List<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts);
    }
}
