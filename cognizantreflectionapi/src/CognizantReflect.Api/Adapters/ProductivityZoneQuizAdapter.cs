using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using MongoDB.Driver;

namespace CognizantReflect.Api.Adapters
{
    internal class ProductivityZoneQuizAdapter : IProductivityZoneQuizAdapter
    {
        private readonly IMongoClientHelper<ProductivityZoneQuiz> _productivityZoneQuiz;
        private readonly IMongoClientHelper<ProductivityZoneQuizAttempts> _productivityZoneQuizAttempts;
        private readonly string _productivityZoneQuizCollection;
        private readonly string _productivityZoneQuizAttemptCollection;
        public ProductivityZoneQuizAdapter(IMongoClientHelper<ProductivityZoneQuiz> productivityZoneQuiz, IMongoClientHelper<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts, 
            IOptions<MongoDbSettings> options)
        {
            _productivityZoneQuiz = productivityZoneQuiz;
            _productivityZoneQuizAttempts = productivityZoneQuizAttempts;
            _productivityZoneQuizCollection = options.Value.ProductivityZoneQuizCollection;
            _productivityZoneQuizAttemptCollection = options.Value.ProductivityZoneQuizAttemptsCollection;
        }
        public List<ProductivityZoneQuiz> GetProductivityZoneQuizzes()
        {
            var result = _productivityZoneQuiz.GetTotalRecords(_productivityZoneQuizCollection);
            List<ProductivityZoneQuiz> productivityZoneQuizzes = new List<ProductivityZoneQuiz>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("question", out BsonValue questionValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                productivityZoneQuizzes.Add(new ProductivityZoneQuiz
                {
                    id = Common.IntegerNullCheck(idValue),
                    question = Common.StringNullCheck(questionValue),                    
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                });
            }
            return productivityZoneQuizzes;
        }

        public ProductivityZoneQuizAttempts GetLatestId()
        {
            var sort = Builders<ProductivityZoneQuizAttempts>.Sort.Descending(f => f.id);
            return _productivityZoneQuizAttempts.GetLatestId(_productivityZoneQuizCollection, sort);
        }

        public int InsertProductivityZoneQuizAttempts(List<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts)
        {
            _productivityZoneQuizAttempts.InsertAll(productivityZoneQuizAttempts, _productivityZoneQuizAttemptCollection);
            return 1;
        }

        public int InsertProductivityZoneQuiz(ProductivityZoneQuiz productivityZoneQuiz)
        {
            _productivityZoneQuiz.InsertOne(productivityZoneQuiz, _productivityZoneQuizCollection);
            return 1;
        }

        public ProductivityZoneQuizAttempts GetLatestAttemptByUser(string userid)
        {
            var filter = Builders<ProductivityZoneQuizAttempts>.Filter.Eq("userid", userid);
            return _productivityZoneQuizAttempts.GetData(filter, _productivityZoneQuizAttemptCollection)?
                .OrderByDescending(x => x.attemptcount)?.FirstOrDefault();
        }
    }
}
