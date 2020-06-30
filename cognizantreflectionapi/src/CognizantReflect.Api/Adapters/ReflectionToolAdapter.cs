using System.Collections.Generic;
using System.Linq;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Handlers;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CognizantReflect.Api.Adapters
{
    internal class ReflectionToolAdapter : IReflectionToolAdapter
    {
        private readonly IMongoClientHelper<ReflectionTool> _reflectionToolClientHelper;
        private readonly IMongoClientHelper<ReflectionToolQuizAttempt> _reflectionQuizAttemptsClientHelper;
        private readonly string _reflectionToolCollection;
        private readonly string _reflectionQuizAttemptsCollection;

        public ReflectionToolAdapter(IMongoClientHelper<ReflectionTool> reflectionToolClientHelper,
            IMongoClientHelper<ReflectionToolQuizAttempt> reflectionQuizAttemptsClientHelper,
            IOptions<MongoDbSettings> settings)
        {
            _reflectionToolClientHelper = reflectionToolClientHelper;
            _reflectionQuizAttemptsClientHelper = reflectionQuizAttemptsClientHelper;
            _reflectionToolCollection = settings.Value.ReflectionToolQuizCollection;
            _reflectionQuizAttemptsCollection = settings.Value.ReflectionToolQuizAttemptsCollection;
        }


        public List<ReflectionTool> GetReflectionToolQuestions()
        {
            return _reflectionToolClientHelper.GetData(FilterDefinition<ReflectionTool>.Empty,
                _reflectionToolCollection);
        }

        public void SaveReflectionToolQuizAttempt(List<ReflectionToolQuizAttempt> reflectionToolAttempt)
        {
            _reflectionQuizAttemptsClientHelper.InsertAll(reflectionToolAttempt, _reflectionQuizAttemptsCollection);
        }

        public long GetLastInsertedReflectionQuizId()
        {
            return _reflectionQuizAttemptsClientHelper.GetData(
                    FilterDefinition<ReflectionToolQuizAttempt>.Empty,
                     _reflectionQuizAttemptsCollection)?.OrderByDescending(x=>x.id)
                .FirstOrDefault()
                ?.id ?? 0;
        }

        public int GetAttemptCountForReflectionToolQuiz(string userid)
        {
            var result = _reflectionQuizAttemptsClientHelper.GetData(FilterDefinitionHandler.FilterReflectionToolQuizByUserId(userid),
                 _reflectionQuizAttemptsCollection)?.OrderByDescending(x=>x.attemptcount);

            if (result.Any())
            {
                return result.FirstOrDefault().attemptcount;
            }


            return 0;

        }

        public List<ReflectionToolQuizAttempt> GetReflectionToolAttempts(string userid, int attemptCount)
        {
            var result = _reflectionQuizAttemptsClientHelper.GetData(
                FilterDefinitionHandler.FilterReflectionByUserAndAttemptCount(userid, attemptCount)
                , _reflectionQuizAttemptsCollection);

            return result;
        }

        public ReflectionToolQuizAttempt GetLatestAttemptByUser(string userid)
        {
            var filter = Builders<ReflectionToolQuizAttempt>.Filter.Eq("userid", userid);
            return _reflectionQuizAttemptsClientHelper.GetData(filter, _reflectionQuizAttemptsCollection)?
                .OrderByDescending(x => x.attemptcount)?.FirstOrDefault();
        }

        public ReflectionToolQuizAttempt GetLatestAttemptId()
        {
         
            return _reflectionQuizAttemptsClientHelper.GetData(FilterDefinition<ReflectionToolQuizAttempt>.Empty, _reflectionQuizAttemptsCollection)?
                .OrderByDescending(x => x.id)?.FirstOrDefault();
        }
    }
}
