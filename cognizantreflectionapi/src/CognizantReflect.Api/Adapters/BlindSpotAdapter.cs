using System.Collections.Generic;
using System.Linq;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Handlers;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CognizantReflect.Api.Adapters
{
    internal class BlindSpotAdapter:IBlindSpotAdapter
    {
        private readonly IMongoClientHelper<BlindSpotQuizAttempts> _blindSpotAttemptsMongoHelper;
        private readonly IMongoClientHelper<BlindSpotQuizQuestions> _blindSpotQuestionsMongoHelper;
        private readonly IMongoClientHelper<BlindSpotCoWorkerReply> _blindSpotCoWorkerMongoHelper;
        private readonly string _blindSpotQuizCollection;
        private readonly string _blindSpotAttemptCollection;
        private readonly string _blindSpotCoWorkerResponseCollection;

        public BlindSpotAdapter(IMongoClientHelper<BlindSpotQuizAttempts> blindSpotAttemptsMongoHelper,
            IMongoClientHelper<BlindSpotQuizQuestions> blindSpotQuestionsMongoHelper,
            IMongoClientHelper<BlindSpotCoWorkerReply> blindSpotCoWorkerMongoHelper, IOptions<MongoDbSettings> settings)
        {
            _blindSpotAttemptsMongoHelper = blindSpotAttemptsMongoHelper;
            _blindSpotQuestionsMongoHelper = blindSpotQuestionsMongoHelper;
            _blindSpotCoWorkerMongoHelper = blindSpotCoWorkerMongoHelper;
            _blindSpotQuizCollection = settings.Value.BlindSpotQuizCollection;
            _blindSpotAttemptCollection = settings.Value.BlindSpotQuizAttemptsCollection;
            _blindSpotCoWorkerResponseCollection = settings.Value.BlindSpotQuizCoWorkerReplyCollection;
        }

        public BlindSpotQuizQuestions GetBlindSpotQuizQuestions()
        {
            var result = _blindSpotQuestionsMongoHelper.GetTotalRecords(_blindSpotQuizCollection);

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("adjectives", out BsonValue adjectivesValue);
                item.TryGetValue("selectedcwmaxcount", out BsonValue selectcwCountValue);
                item.TryGetValue("selectedadmaxcount", out BsonValue selectedadmaxcountValue);
                item.TryGetValue("updatetimestamp", out BsonValue updatetimestampValue);
                return new BlindSpotQuizQuestions
                {
                    id = Common.IntegerNullCheck(idValue),
                    adjectives = Common.StringNullCheck(adjectivesValue)?.Trim('[').Trim(']').Split(","),
                    selectedcwmaxcount = Common.IntegerNullCheck(selectcwCountValue),
                    selectedadmaxcount = Common.IntegerNullCheck(selectedadmaxcountValue),
                    updatetimestamp = Common.StringNullCheck(updatetimestampValue)
                };
            }
            return new BlindSpotQuizQuestions();
        }

        public BlindSpotQuizAttempts GetBlindSpotAttemptResponse(int attemptid,string userid)
        {
            var attemptidFilter = Builders<BsonDocument>.Filter.Eq("attemptid", attemptid);
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userid);
            var result = _blindSpotQuestionsMongoHelper.GetRecords(_blindSpotAttemptCollection, attemptidFilter & userFilter);
            List<BlindSpotQuizAttempts> blindSpotAttempts = new List<BlindSpotQuizAttempts>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("attemptcount", out BsonValue attemptcountValue);
                item.TryGetValue("selectedadjectives", out BsonValue selectedadjectivesValue);
                item.TryGetValue("selectedcoWorkers", out BsonValue selectedcoWorkersValue);
                item.TryGetValue("status", out BsonValue statusValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("replytimestamp", out BsonValue replytimestampValue);
                blindSpotAttempts.Add(new BlindSpotQuizAttempts
                {
                    id = Common.IntegerNullCheck(idValue),
                    attemptcount = Common.IntegerNullCheck(attemptcountValue),
                    selectedadjectives = Common.StringNullCheck(selectedadjectivesValue).Split(","),
                    userid = Common.StringNullCheck(useridValue),
                    selectedcoWorkers = Common.StringNullCheck(selectedcoWorkersValue).Split(","),
                    status = Common.StringNullCheck(statusValue),
                    attempttimestamp = Common.StringNullCheck(replytimestampValue)
                });
            }
            return blindSpotAttempts.FirstOrDefault();
        }
        /// <summary>
        /// For getting the coworker reply by the attempt id(id in the blindspot quiz attempt table)
        /// </summary>
        /// <param name="attemptid"></param>
        /// <returns></returns>
        public List<BlindSpotCoWorkerReply> GetDataForCoWorkerReply(int attemptid)
        {
            var attemptidFilter = Builders<BsonDocument>.Filter.Eq("attemptid", attemptid);
            var result = _blindSpotQuestionsMongoHelper.GetRecords(_blindSpotCoWorkerResponseCollection, attemptidFilter);
            List<BlindSpotCoWorkerReply> blindSpotCoWorkers = new List<BlindSpotCoWorkerReply>();

            foreach (var item in result)
            {
                item.TryGetValue("_id", out BsonValue idValue);
                item.TryGetValue("attemptid", out BsonValue attemptidValue);
                item.TryGetValue("selectedadjectives", out BsonValue selectedadjectivesValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("replytimestamp", out BsonValue replytimestampValue);
                blindSpotCoWorkers.Add(new BlindSpotCoWorkerReply
                {
                    id = Common.IntegerNullCheck(idValue),
                    attemptid = Common.IntegerNullCheck(attemptidValue),
                    selectedadjectives = Common.StringNullCheck(selectedadjectivesValue).Split(","),
                    userid = Common.StringNullCheck(useridValue),
                    replytimestamp = Common.StringNullCheck(replytimestampValue)
                });
            }
            return blindSpotCoWorkers;
        }


        public void SaveBlindSpotUserResponse(BlindSpotQuizAttempts response)
        { 
            _blindSpotAttemptsMongoHelper.InsertOne(response,_blindSpotAttemptCollection);
        }

        public void SaveBlindSpotCoWorkerResponse(BlindSpotCoWorkerReply response)
        {
            _blindSpotCoWorkerMongoHelper.InsertOne(response, _blindSpotCoWorkerResponseCollection);
        }

        public void UpdateBlindSpotCoWorkerResponse(BlindSpotCoWorkerReply response)
        {
            _blindSpotCoWorkerMongoHelper.UpdateOne(UpdateDefinitionHandler.UpdateCoWorkerResponse(response.selectedadjectives),
                FilterDefinitionHandler.FilterCoWorkerResponsesByReplyId(response.id), _blindSpotCoWorkerResponseCollection);
        }


        public BlindSpotQuizAttempts GetLatestAttemptByUser(string user)
        {
    
            var userAttempts = _blindSpotAttemptsMongoHelper.GetData(
                FilterDefinitionHandler.FilterBlindSpotQuizByUserId(user)
                , _blindSpotAttemptCollection);
            return userAttempts.Where(att => att.attemptcount == userAttempts?.Max(x => x.attemptcount))?.FirstOrDefault();


        }

        public List<BlindSpotCoWorkerReply> GetCoWorkerResponsesByAttempt(long attemptId)
        {
            return _blindSpotCoWorkerMongoHelper.GetData(
                FilterDefinitionHandler.FilterCoWorkerResponsesByAttemptId(attemptId),
                _blindSpotCoWorkerResponseCollection);

        }

        public long GetLastInsertedAttemptId()
        {
            return _blindSpotAttemptsMongoHelper.GetData(FilterDefinition<BlindSpotQuizAttempts>.Empty,
                _blindSpotAttemptCollection)?.OrderByDescending(x=>x.id).FirstOrDefault()
                ?.id ?? 0;
        }

        public long GetLastInsertedCoWorkerReply()
        {
            return _blindSpotCoWorkerMongoHelper.GetData(FilterDefinition<BlindSpotCoWorkerReply>.Empty,
                _blindSpotCoWorkerResponseCollection)?.OrderByDescending(x=>x.id).FirstOrDefault()
                ?.id ?? 0;
        }

        public List<BlindSpotCoWorkerReply> GetDataForCoWorkerReply(string userid)
        {
            throw new System.NotImplementedException();
        }
    }
}
