using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.CuriosityQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CognizantReflect.Api.Adapters
{
    internal class CuriousQuizAdapter : ICuriousQuizAdapter
    {
        private readonly IMongoClientHelper<CuriousQuiz> _curiousQuiz;
        private readonly IMongoClientHelper<CuriousQuizAttempts> _curiousQuizAttempts;
        private readonly string _curiousQuizCollection;
        private readonly string _curiousQuizAttemptsCollection;
        public CuriousQuizAdapter(IMongoClientHelper<CuriousQuiz> curiousQuiz, IMongoClientHelper<CuriousQuizAttempts> curiousQuizAttempts,IOptions<MongoDbSettings> options)
        {
            _curiousQuiz = curiousQuiz;
            _curiousQuizAttempts = curiousQuizAttempts;
            _curiousQuizCollection = options.Value.CuriousQuizCollection;
            _curiousQuizAttemptsCollection = options.Value.CuriousQuizAttemptsCollection;
        }

        public List<CuriousQuiz> GetCuriosQuizzes()
        {
            var result = _curiousQuiz.GetTotalRecords(_curiousQuizCollection);
            List<CuriousQuiz> curiousQuizzes = new List<CuriousQuiz>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("question", out BsonValue questionValue);
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("score", out BsonValue scoreValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                curiousQuizzes.Add(new CuriousQuiz
                {                    
                    id = Common.IntegerNullCheck(idValue),
                    question = Common.StringNullCheck(questionValue),
                    answer = Common.BooleanNullCheck(answerValue),
                    score = Common.IntegerNullCheck(scoreValue),
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                });
            }
            return curiousQuizzes;
        }

        public int InsertCuriosQuiz(CuriousQuiz curiosQuiz)
        {

            _curiousQuiz.InsertOne(curiosQuiz,_curiousQuizCollection);
            return 1;
        }

        public int InsertCuriosQuizResponse(List<CuriousQuizAttempts> curiosQuizAttempts)
        {
            _curiousQuizAttempts.InsertAll(curiosQuizAttempts, _curiousQuizAttemptsCollection);
            return 1;

        }

        public CuriousQuizAttempts GetLatestId()
        {
            var sort = Builders<CuriousQuizAttempts>.Sort.Descending(f => f.id);
            return _curiousQuizAttempts.GetLatestId(_curiousQuizAttemptsCollection, sort);
        }


        public CuriousQuizAttempts GetLatestAttemptByUser(string userid)
        {
      
            var filter = Builders<CuriousQuizAttempts>.Filter.Eq("userid", userid);
            return _curiousQuizAttempts.GetData(filter,_curiousQuizAttemptsCollection)?
                .OrderByDescending(x=>x.attemptcount)?.FirstOrDefault();
        }

        public List<CuriousQuizAttempts> GetCuriousAttempts(string userid, int attemptCount)
        {
            var userFilter = Builders<CuriousQuizAttempts>.Filter.Eq("userid", userid);
            var attemptFilter = Builders<CuriousQuizAttempts>.Filter.Eq("attemptcount", attemptCount);
            var userAndAttempt = Builders<CuriousQuizAttempts>.Filter.And(userFilter, attemptFilter);
            return _curiousQuizAttempts.GetData(userAndAttempt,_curiousQuizAttemptsCollection);
        }
        
    }
}
