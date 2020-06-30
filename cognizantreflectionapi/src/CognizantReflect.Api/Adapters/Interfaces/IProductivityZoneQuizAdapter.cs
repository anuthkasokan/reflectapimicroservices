using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IProductivityZoneQuizAdapter
    {
        List<ProductivityZoneQuiz> GetProductivityZoneQuizzes();

        int InsertProductivityZoneQuiz(ProductivityZoneQuiz productivityZoneQuiz);

        int InsertProductivityZoneQuizAttempts(List<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts);

        ProductivityZoneQuizAttempts GetLatestId();

        ProductivityZoneQuizAttempts GetLatestAttemptByUser(string userid);
    }
}
