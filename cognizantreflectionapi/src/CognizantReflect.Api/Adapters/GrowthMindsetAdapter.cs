using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CognizantReflect.Api.Adapters
{
    internal class GrowthMindsetAdapter : IGrowthMindsetAdapter
    {
        private readonly IMongoClientHelper<GrowthMindsetQuiz> _growthMindsetQuiz;
        private readonly IMongoClientHelper<GrowthMindsetQuizAttempts> _growthMindsetQuizAttempts;
        private readonly string _growthMindsetQuizCollection;
        private readonly string _growthMindsetQuizAttemptsCollection;
        public GrowthMindsetAdapter(IMongoClientHelper<GrowthMindsetQuiz> growthMindsetQuiz, IMongoClientHelper<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts, IOptions<MongoDbSettings> options)
        {
            _growthMindsetQuiz = growthMindsetQuiz;
            _growthMindsetQuizAttempts = growthMindsetQuizAttempts;
            _growthMindsetQuizCollection = options.Value.GrowthMindsetQuizCollection;
            _growthMindsetQuizAttemptsCollection = options.Value.GrowthMindsetAttemptsQuizCollection;
        }
        public List<GrowthMindsetQuiz> GetGrowthMindsetQuiz()
        {
            var result = _growthMindsetQuiz.GetTotalRecords(_growthMindsetQuizCollection);
            List<GrowthMindsetQuiz> growthMindsetQuizzes = new List<GrowthMindsetQuiz>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("question", out BsonValue questionValue);
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("score", out BsonValue scoreValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                growthMindsetQuizzes.Add(new GrowthMindsetQuiz
                {
                    id = Common.IntegerNullCheck(idValue),
                    question = Common.StringNullCheck(questionValue),
                    answer = Common.BooleanNullCheck(answerValue),
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                });
            }
            return growthMindsetQuizzes;
        }

        public int InsertGrowthMindsetQuiz(GrowthMindsetQuiz growthMindsetQuiz)
        {
            _growthMindsetQuiz.InsertOne(growthMindsetQuiz, _growthMindsetQuizCollection);
            return 1;
        }

        public int InsertGrowthMindsetQuizAttempts(List<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts)
        {
            _growthMindsetQuizAttempts.InsertAll(growthMindsetQuizAttempts, _growthMindsetQuizAttemptsCollection);
            return 1;
        }

        public GrowthMindsetQuizAttempts GetLatestId()
        {
            var sort = Builders<GrowthMindsetQuizAttempts>.Sort.Descending(f => f.id);
            return _growthMindsetQuizAttempts.GetLatestId(_growthMindsetQuizAttemptsCollection, sort);
        }

        public GrowthMindsetQuizAttempts GetLatestAttemptByUser(string userid)
        {
            var filter = Builders<GrowthMindsetQuizAttempts>.Filter.Eq("userid", userid);
            return _growthMindsetQuizAttempts.GetData(filter, _growthMindsetQuizAttemptsCollection)?
                .OrderByDescending(x => x.attemptcount)?.FirstOrDefault();
        }
    }
}
