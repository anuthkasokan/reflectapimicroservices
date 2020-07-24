using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using MongoDB.Driver;

namespace CognizantReflect.Api.Adapters
{
    internal class StoryTellingForImpactAdapter : IStoryTellingForImpactAdapter
    {
        private readonly IMongoClientHelper<StoryTellingForImpactQuiz> _storyTellingForImpactQuiz;
        private readonly IMongoClientHelper<StoryTellingForImpactQuizAttempts> _storyTellingForImpactQuizAttempts;
        private readonly string _storyTellingForImpactQuizCollection;
        private readonly string _storyTellingForImpactAttemptsCollection;
        public StoryTellingForImpactAdapter(IMongoClientHelper<StoryTellingForImpactQuiz> storyTellingForImpactQuiz, IOptions<MongoDbSettings> options,
            IMongoClientHelper<StoryTellingForImpactQuizAttempts> storyTellingForImpactQuizAttempts)
        {
            _storyTellingForImpactQuiz = storyTellingForImpactQuiz;
            _storyTellingForImpactQuizAttempts = storyTellingForImpactQuizAttempts;
            _storyTellingForImpactQuizCollection = options.Value.StoryTellingForImpactQuizCollection;
            _storyTellingForImpactAttemptsCollection = options.Value.StoryTellingForImpactQuizAttemptsCollection;
        }

        public List<StoryTellingForImpactQuiz> GetStoryTellingForImpactQuizzes()
        {
            var result = _storyTellingForImpactQuiz.GetTotalRecords(_storyTellingForImpactQuizCollection);
            List<StoryTellingForImpactQuiz> storyTellingForImpactQuizzes = new List<StoryTellingForImpactQuiz>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("question", out BsonValue questionValue);
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("statement", out BsonValue statementValue);
                item.TryGetValue("type", out BsonValue typeValue);
                item.TryGetValue("options", out BsonValue optionsValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                storyTellingForImpactQuizzes.Add(new StoryTellingForImpactQuiz
                {
                    id = Common.IntegerNullCheck(idValue),
                    question = Common.StringNullCheck(questionValue),
                    answer = Common.StringNullCheck(answerValue),
                    statement = Common.StringNullCheck(statementValue),
                    type = Common.StringNullCheck(typeValue),
                    options = new Optionss
                    {
                        a = Common.StringNullCheck(optionsValue?[0]),
                        b = Common.StringNullCheck(optionsValue?[1]),
                        c = Common.StringNullCheck(optionsValue?[2]),
                        d = Common.StringNullCheck(optionsValue?[3])
                    },
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                });
            }
            return storyTellingForImpactQuizzes;
        }               

        public int InsertStoryTellingForImpactQuizzes(StoryTellingForImpactQuiz storyTellingForImpactQuiz)
        {
            _storyTellingForImpactQuiz.InsertOne(storyTellingForImpactQuiz, _storyTellingForImpactQuizCollection);
            return 1;
        }

        public int InsertStoryTellingForImpactQuizzAttempts(List<StoryTellingForImpactQuizAttempts> storyTellingForImpactQuizAttempts)
        {
            _storyTellingForImpactQuizAttempts.InsertAll(storyTellingForImpactQuizAttempts, _storyTellingForImpactAttemptsCollection);
            return 1;
        }

        public StoryTellingForImpactQuizAttempts GetLatestId()
        {
            var sort = Builders<StoryTellingForImpactQuizAttempts>.Sort.Descending(f => f.id);
            return _storyTellingForImpactQuizAttempts.GetLatestId(_storyTellingForImpactAttemptsCollection, sort);
        }

        public StoryTellingForImpactQuizAttempts GetLatestAttemptByUser(string userid)
        {
            var filter = Builders<StoryTellingForImpactQuizAttempts>.Filter.Eq("userid", userid);
            return _storyTellingForImpactQuizAttempts.GetData(filter, _storyTellingForImpactAttemptsCollection)?
                .OrderByDescending(x => x.attemptcount)?.FirstOrDefault();
        }
    }
}
