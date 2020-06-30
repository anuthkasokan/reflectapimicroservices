using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class ProductivityZoneQuizBusinessLogic : IProductivityZoneQuizBusinessLogic
    {
        private readonly IProductivityZoneQuizAdapter _productivityZoneQuizAdapter;
        public ProductivityZoneQuizBusinessLogic(IProductivityZoneQuizAdapter productivityZoneQuizAdapter)
        {
            _productivityZoneQuizAdapter = productivityZoneQuizAdapter;
        }
        public List<ProductivityZoneQuiz> GetProductivityZoneQuizzes()
        {
            return _productivityZoneQuizAdapter.GetProductivityZoneQuizzes();
        }

        public void InsertProductivityZoneQuizzes(ProductivityZoneQuiz productivityZoneQuiz)
        {
            _productivityZoneQuizAdapter.InsertProductivityZoneQuiz(productivityZoneQuiz);

        }

        public void InsertProductivityZoneQuizAttempts(List<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts)
        {
            var latestDetails = _productivityZoneQuizAdapter.GetLatestId();
            var latestId = 0;
            var attemptId = _productivityZoneQuizAdapter.GetLatestAttemptByUser(productivityZoneQuizAttempts[0].userid);
            if (latestDetails != null)
            {
                latestId = latestDetails.id;
            }
            foreach (var item in productivityZoneQuizAttempts)
            {
                latestId++;
                item.id = latestId;
                item.attemptcount = (attemptId?.attemptcount??0) +1;
                item.attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
            _productivityZoneQuizAdapter.InsertProductivityZoneQuizAttempts(productivityZoneQuizAttempts);
        }


    }
}
