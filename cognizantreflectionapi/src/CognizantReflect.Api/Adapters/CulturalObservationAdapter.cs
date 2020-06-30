using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using MongoDB.Driver;

namespace CognizantReflect.Api.Adapters
{
    internal class CulturalObservationAdapter : ICulturalObservationAdapter
    {
        private readonly IMongoClientHelper<CultureObservationToolQuiz> _cultureObservationToolQuiz;
        private readonly IMongoClientHelper<CultureObservationToolQuizAttempts> _cultureObservationClientHelper;
        private readonly string _cultureObservationToolQuizCollection;
        private readonly string _cultureObservationAttemptCollection;

        public CulturalObservationAdapter(IMongoClientHelper<CultureObservationToolQuiz> cultureObservationToolQuiz,IMongoClientHelper<CultureObservationToolQuizAttempts> cultureObservationAttempt,
            IOptions<MongoDbSettings> options)
        {
            _cultureObservationToolQuiz = cultureObservationToolQuiz;
            _cultureObservationClientHelper = cultureObservationAttempt;
            _cultureObservationToolQuizCollection = options.Value.CultureObservationToolQuizCollection;
            _cultureObservationAttemptCollection = options.Value.ReflectionToolQuizAttemptsCollection;
        }
        public List<CultureObservationToolQuiz> GetCutlturalObservationQuiz()
        {
            var result = _cultureObservationToolQuiz.GetTotalRecords(_cultureObservationToolQuizCollection);
            List<CultureObservationToolQuiz> cultureObservationToolQuizzes = new List<CultureObservationToolQuiz>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("question", out BsonValue questionValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                cultureObservationToolQuizzes.Add(new CultureObservationToolQuiz
                {
                    id = Common.IntegerNullCheck(idValue),
                    question = Common.StringNullCheck(questionValue),
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                });
            }
            return cultureObservationToolQuizzes;
        }

        public void InsertCultureObservationAttempt(List<CultureObservationToolQuizAttempts> cultureObservationAttempts)
        {
            _cultureObservationClientHelper.InsertAll(cultureObservationAttempts,_cultureObservationAttemptCollection);
        }

        public CultureObservationToolQuizAttempts GetLatestAttemptByUser(string userid)
        {
            var filter = Builders<CultureObservationToolQuizAttempts>.Filter.Eq("userid", userid);
            return _cultureObservationClientHelper.GetData(filter, _cultureObservationAttemptCollection)?.OrderByDescending(x=>x.attemptcount)?.FirstOrDefault();
        }

        public CultureObservationToolQuizAttempts GetLatestAttemptId()
        {

            return _cultureObservationClientHelper.GetData(FilterDefinition<CultureObservationToolQuizAttempts>.Empty, 
                _cultureObservationAttemptCollection)?.OrderByDescending(x => x.id)?
                .FirstOrDefault();
        }
    }
}
