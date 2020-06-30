using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CognizantReflect.Api.Adapters
{
    internal class LearningMythsAdapter : ILearningMythsAdapter
    {
        private readonly IMongoClientHelper<LearningMythsQuiz> _learningMythQuiz;
        private readonly IMongoClientHelper<LearningMythsQuizAttempts> _learningMythQuizAttempts; 
        private readonly string _learningMythQuizCollection;
        private readonly string _learningMythQuizAttemptsCollection;
        public LearningMythsAdapter(IMongoClientHelper<LearningMythsQuiz> learningMythQuiz, IMongoClientHelper<LearningMythsQuizAttempts> learningMythQuizAttempts,
            IOptions<MongoDbSettings> options)
        {
            _learningMythQuiz = learningMythQuiz;
            _learningMythQuizAttempts = learningMythQuizAttempts;
            _learningMythQuizCollection = options.Value.LearningMythsQuizCollection;
            _learningMythQuizAttemptsCollection = options.Value.LearningMythsQuizAttemptsCollection;
        }

        public List<LearningMythsQuiz> GetLearningMythsQuizzes()
        {
            var result = _learningMythQuiz.GetTotalRecords(_learningMythQuizCollection);
            List<LearningMythsQuiz> curiousQuizzes = new List<LearningMythsQuiz>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("question", out BsonValue questionValue);
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("options", out BsonValue optionsValue);
                item.TryGetValue("type", out BsonValue typeValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                curiousQuizzes.Add(new LearningMythsQuiz
                {
                    id = Common.IntegerNullCheck(idValue),
                    question = Common.StringNullCheck(questionValue),
                    answer = Common.StringNullCheck(answerValue),
                    options = new Optionss
                    {
                        a = Common.StringNullCheck(optionsValue?[0]),
                        b = Common.StringNullCheck(optionsValue?[1]),
                        c = Common.StringNullCheck(optionsValue?[2]),
                        d = Common.StringNullCheck(optionsValue?[3])
                    },
                    type = Common.StringNullCheck(typeValue),
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                }); 
            }
            return curiousQuizzes;
        }

        public LearningMythsQuizAttempts GetLatestId()
        {
            var sort = Builders<LearningMythsQuizAttempts>.Sort.Descending(f => f.id);
            return _learningMythQuizAttempts.GetLatestId(_learningMythQuizAttemptsCollection, sort);
        }

        public int InsertLearningMythQuizAttempts(List<LearningMythsQuizAttempts> learningMythsQuizAttempts)
        {
            _learningMythQuizAttempts.InsertAll(learningMythsQuizAttempts, _learningMythQuizAttemptsCollection);
            return 1;
        }

        public LearningMythsQuizAttempts GetLatestAttemptByUser(string userid)
        {
            var filter = Builders<LearningMythsQuizAttempts>.Filter.Eq("userid", userid);
            return _learningMythQuizAttempts.GetData(filter, _learningMythQuizAttemptsCollection)?
                .OrderByDescending(x => x.attemptcount)?.FirstOrDefault();
        }
    }
}
