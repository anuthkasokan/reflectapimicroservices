using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CognizantReflect.Api.Adapters
{
    internal class ContinuousLearningAdapter : IContinuousLearningAdapter
    {
        private readonly IMongoClientHelper<ContinuousLearningAssessmentQuiz> _continuousLearningAssessmentQuiz;
        private readonly IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts> _continuousLearningAssessmentQuizAttempt;
        private readonly string _continuousLearningAssessmentQuizCollection;
        private readonly string _continuousLearningAssessmentQuizAttemptCollection;
        public ContinuousLearningAdapter(IMongoClientHelper<ContinuousLearningAssessmentQuiz> continuousLearningAssessmentQuiz,
            IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts> continuousLearningAssessmentQuizAttempt, IOptions<MongoDbSettings> options)
        {
            _continuousLearningAssessmentQuiz = continuousLearningAssessmentQuiz;
            _continuousLearningAssessmentQuizAttempt = continuousLearningAssessmentQuizAttempt;
            _continuousLearningAssessmentQuizCollection = options.Value.ContinuousLearningAssessmentQuizCollection;
            _continuousLearningAssessmentQuizAttemptCollection = options.Value.ContinuousLearningAssessmentQuizAttemptsCollection;

        }
        public List<ContinuousLearningAssessmentQuiz> GetContinuousLearningAssessmentQuizzes()
        {
            var result = _continuousLearningAssessmentQuiz.GetTotalRecords(_continuousLearningAssessmentQuizCollection);
            List<ContinuousLearningAssessmentQuiz> continuousLearningAssessmentQuizzes = new List<ContinuousLearningAssessmentQuiz>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("question", out BsonValue questionValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                continuousLearningAssessmentQuizzes.Add(new ContinuousLearningAssessmentQuiz
                {
                    id = Common.IntegerNullCheck(idValue),
                    question = Common.StringNullCheck(questionValue),                    
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                }); 
            }
            return continuousLearningAssessmentQuizzes;
        }

        public ContinuousLearningAssessmentQuizAttempts GetLatestId()
        {
            var sort = Builders<ContinuousLearningAssessmentQuizAttempts>.Sort.Descending(f => f.id);
            return _continuousLearningAssessmentQuizAttempt.GetLatestId(_continuousLearningAssessmentQuizAttemptCollection, sort);
        }

        public int InsertContinuousLearningAssessmentQuizResponse(List<ContinuousLearningAssessmentQuizAttempts> continuousLearningAssessmentQuizAttempts)
        {
            _continuousLearningAssessmentQuizAttempt.InsertAll(continuousLearningAssessmentQuizAttempts, _continuousLearningAssessmentQuizAttemptCollection);
            return 1;
        }

        public ContinuousLearningAssessmentQuizAttempts GetLatestAttemptByUser(string userid)
        {
            var filter = Builders<ContinuousLearningAssessmentQuizAttempts>.Filter.Eq("userid", userid);
            return _continuousLearningAssessmentQuizAttempt.GetData(filter, _continuousLearningAssessmentQuizAttemptCollection)?.OrderByDescending(x=>x.attemptcount)?.FirstOrDefault();
        }
    }
}
