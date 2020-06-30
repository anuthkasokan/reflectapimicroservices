using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.Reports;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using CognizantReflect.Api.Models.CuriosityQuiz;
using CognizantReflect.Api.Models.ReflectionToolQuiz;

namespace CognizantReflect.Api.Adapters
{
    internal class ReportsAdapter : IReportsAdapter
    {
        private readonly IMongoClientHelper<QuizAttempts> _quizAttempt;
        private readonly ICuriousQuizAdapter _curiousQuizAdapter;
        private readonly IGrowthMindsetAdapter _growthMindsetQuizAdapter;
        private readonly IMakingTimeForMeQuizAdapter _makingTimeForMeQuizAdapter;
        private readonly IStoryTellingForImpactAdapter _storyTellingForImpactAdapter;
        private readonly IContinuousLearningAdapter _continuousLearningAdapter;
        private readonly IBlindSpotAdapter _blindSpotAdapter;
        private readonly ILearningMythsAdapter _learningMythAdapter;
        private readonly ICulturalObservationAdapter _culturalObservationAdapter;
        private readonly IProductivityZoneQuizAdapter _productivityZoneQuizAdapter;
        private readonly IReflectionToolAdapter _reflectionToolAdapter;
        private readonly string _curiousQuizAttemptsCollection;
        private readonly string _quizDetailsCollection;
        private readonly string _growthMindsetAttemptsCollection;
        private readonly string _learningMythAttemptsCollection;
        private readonly string _continuousLearningAttemptsCollection;
        private readonly string _culturalObservationAttemptsCollection;
        private readonly string _productivityZoneAttemptsCollection;
        private readonly string _reflectionToolAttemptsCollection;
        private readonly string _makingTimeForMeAttemptsCollection;
        private readonly string _storyTellingAttemptsCollection;


        public ReportsAdapter(IMongoClientHelper<QuizAttempts> quizAttempt, IOptions<MongoDbSettings> options, ICuriousQuizAdapter curiousQuizAdapter,
            IGrowthMindsetAdapter growthMindsetQuizAdapter, IMakingTimeForMeQuizAdapter makingTimeForMeQuizAdapter, 
            IStoryTellingForImpactAdapter storyTellingForImpactAdapter, IBlindSpotAdapter blindSpotAdapter, ILearningMythsAdapter learningMythAdapter,
            IContinuousLearningAdapter continuousLearningAdapter, ICulturalObservationAdapter culturalObservationAdapter,
            IProductivityZoneQuizAdapter productivityZoneQuizAdapter,IReflectionToolAdapter reflectionToolAdapter)
        {
            _quizAttempt = quizAttempt;
            _curiousQuizAdapter = curiousQuizAdapter;
            _growthMindsetQuizAdapter = growthMindsetQuizAdapter;
            _makingTimeForMeQuizAdapter = makingTimeForMeQuizAdapter;
            _storyTellingForImpactAdapter = storyTellingForImpactAdapter;
            _blindSpotAdapter = blindSpotAdapter;
            _continuousLearningAdapter = continuousLearningAdapter;
            _learningMythAdapter = learningMythAdapter;
            _productivityZoneQuizAdapter = productivityZoneQuizAdapter;
            _culturalObservationAdapter = culturalObservationAdapter;
            _reflectionToolAdapter = reflectionToolAdapter;
            _curiousQuizAttemptsCollection = options.Value.CuriousQuizAttemptsCollection;
            _quizDetailsCollection = options.Value.quizDetailsCollection;
            _growthMindsetAttemptsCollection = options.Value.GrowthMindsetAttemptsQuizCollection;
            _learningMythAttemptsCollection = options.Value.LearningMythsQuizAttemptsCollection;
            _continuousLearningAttemptsCollection = options.Value.ContinuousLearningAssessmentQuizAttemptsCollection;
            _culturalObservationAttemptsCollection = options.Value.CultureObservationToolQuizAttemptsCollection;
            _productivityZoneAttemptsCollection = options.Value.ProductivityZoneQuizAttemptsCollection;
            _reflectionToolAttemptsCollection = options.Value.ReflectionToolQuizAttemptsCollection;
            _makingTimeForMeAttemptsCollection = options.Value.MakingTimeForMeQuizAttemptsCollection;
            _storyTellingAttemptsCollection = options.Value.StoryTellingForImpactQuizAttemptsCollection;
        }

        public QuizDetails GetQuizDetails(int quizId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("quizid", quizId);
            var quizDetailsResult = _quizAttempt.GetSingleRecord(_quizDetailsCollection, filter);
            quizDetailsResult.TryGetValue("quizid", out BsonValue idValue);
            quizDetailsResult.TryGetValue("quizname", out BsonValue quizValue);
            quizDetailsResult.TryGetValue("type", out BsonValue typeValue);
            return  new QuizDetails
            {
                quizid = Common.IntegerNullCheck(idValue),
                quizname = Common.StringNullCheck(quizValue),
                type = Common.StringNullCheck(typeValue)
            };
        }

        public List<QuizDetails> GetAllQuizzes()
        {
            var quizDetailsResult = _quizAttempt.GetTotalRecords(_quizDetailsCollection);
            List<QuizDetails> quizDetails = new List<QuizDetails>();
            foreach(var item in quizDetailsResult)
            {
                item.TryGetValue("quizid", out BsonValue idValue);
                item.TryGetValue("quizname", out BsonValue quizValue);
                item.TryGetValue("type", out BsonValue typeValue);
                quizDetails.Add(new QuizDetails
                {
                    quizid = Common.IntegerNullCheck(idValue),
                    quizname = Common.StringNullCheck(quizValue),
                    type = Common.StringNullCheck(typeValue)
                });
            }
            return quizDetails;            
        }

        public List<QuizAttempts> GetCuriousQuizAttempts(string userId,int attempt, QuizDetails quizDetails)
        {
            var latestAttempt = _curiousQuizAdapter.GetLatestAttemptByUser(userId);
            List<CuriousQuizAttempts> result = new List<CuriousQuizAttempts>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    result = _curiousQuizAdapter.GetCuriousAttempts(userId, latestAttempt.attemptcount);
                }
                else
                {
                    if (latestAttempt.attemptcount >1)
                        result = _curiousQuizAdapter.GetCuriousAttempts(userId, latestAttempt.attemptcount-1);
                }

            }

            var curiousQuizzes = _curiousQuizAdapter.GetCuriosQuizzes();

            List <QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {

                var question = curiousQuizzes.FirstOrDefault(a => a.id == Common.IntegerNullCheck(item.questionid));

                quizAttempts.Add(new QuizAttempts
                {
                    id = question.id,
                    question = question.question,
                    answer = Common.StringNullCheck(item.answer),
                    userId = Common.StringNullCheck(item.userid),
                    attempt = Common.IntegerNullCheck(item.attemptcount),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        public List<QuizAttempts> GetBlindSpotQuizAttempts(string userId,int attempt, QuizDetails quizDetails)
        {
            var latestAttempt = _blindSpotAdapter.GetLatestAttemptByUser(userId);
            BlindSpotQuizAttempts blindSpotAttempts = new BlindSpotQuizAttempts();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    blindSpotAttempts = _blindSpotAdapter.GetBlindSpotAttemptResponse(latestAttempt.attemptcount,userId);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                        blindSpotAttempts = _blindSpotAdapter.GetBlindSpotAttemptResponse( latestAttempt.attemptcount - 1,userId);
                }

            }

            if (blindSpotAttempts?.selectedadjectives == null)
                return new List<QuizAttempts>();

            var blindSpotResponseByCoWorkers = _blindSpotAdapter.GetCoWorkerResponsesByAttempt(blindSpotAttempts.id);
            var coworkerResponses = string.Empty;
            foreach(var coworkerResponse in blindSpotResponseByCoWorkers)
            {
                coworkerResponses += string.Join(",", coworkerResponse.selectedadjectives);
            }

            return new List<QuizAttempts> 
            {  new QuizAttempts
                {
                    question = string.Join(",",blindSpotAttempts.selectedadjectives),
                    answer = coworkerResponses,
                    userId = blindSpotAttempts.userid,
                    attempt = blindSpotAttempts.attemptcount,
                    type = quizDetails.type
                }
            };
        }

        /// <summary>
        /// For getting mind growth attempts
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attempt"></param>
        /// <param name="quizDetails"></param>
        /// <returns></returns>
        public List<QuizAttempts> GetGrowthMindsetQuizAttempts(string userId,int attempt, QuizDetails quizDetails)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userId);

            var latestAttempt = _growthMindsetQuizAdapter.GetLatestAttemptByUser(userId);
            List<BsonDocument> result = new List<BsonDocument>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount);
                    var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                    result = _quizAttempt.GetRecords(_growthMindsetAttemptsCollection, userAndAttempt);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount-1);
                        var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                        result = _quizAttempt.GetRecords(_growthMindsetAttemptsCollection, userAndAttempt);
                    }
                       
                }

            } 

            var mingGrowthQuizzes = _growthMindsetQuizAdapter.GetGrowthMindsetQuiz();

            List <QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("attemptcount", out BsonValue attemptValue);
                item.TryGetValue("questionid", out BsonValue questionidValue);

                var question = mingGrowthQuizzes.Where(a => a.id == Common.IntegerNullCheck(questionidValue));
                quizAttempts.Add(new QuizAttempts
                {
                    question = question.Count() == 0 ? "" : question.Select(a => a.question).FirstOrDefault().ToString(CultureInfo.InvariantCulture),
                    answer =  Common.StringNullCheck(answerValue),
                    userId = Common.StringNullCheck(useridValue),
                    attempt = Common.IntegerNullCheck(attemptValue),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        /// <summary>
        /// for getting continuous learning attempts
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attempt"></param>
        /// <param name="quizDetails"></param>
        /// <returns></returns>
        public List<QuizAttempts> GetContinuousLearningQuizAttempts(string userId, int attempt, QuizDetails quizDetails)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userId);
            var latestAttempt = _continuousLearningAdapter.GetLatestAttemptByUser(userId);
            List<BsonDocument> result = new List<BsonDocument>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount);
                    var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                    result = _quizAttempt.GetRecords(_continuousLearningAttemptsCollection, userAndAttempt);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount - 1);
                        var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                        result = _quizAttempt.GetRecords(_continuousLearningAttemptsCollection, userAndAttempt);
                    }

                }

            }

            var continuousLearningQuizzes = _continuousLearningAdapter.GetContinuousLearningAssessmentQuizzes();

            List<QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("attemptcount", out BsonValue attemptValue);
                item.TryGetValue("questionid", out BsonValue questionidValue);
                item.TryGetValue("yes", out BsonValue yesValue);
                item.TryGetValue("somewhat", out BsonValue somewhatValue);
                item.TryGetValue("no", out BsonValue noValue);
                var answer = Common.BooleanNullCheck(yesValue) ? "Yes" : Common.BooleanNullCheck(somewhatValue) ? "Somewhat" : "No";

                var question = continuousLearningQuizzes.Where(a => a.id == Common.IntegerNullCheck(questionidValue));
                quizAttempts.Add(new QuizAttempts
                {
                    question = question.Count() == 0 ? "" : question.Select(a => a.question).FirstOrDefault().ToString(CultureInfo.InvariantCulture),
                    answer = answer,
                    userId = Common.StringNullCheck(useridValue),
                    attempt = Common.IntegerNullCheck(attemptValue),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        /// <summary>
        /// For getting making time for me Quiz details
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attempt"></param>
        /// <param name="quizDetails"></param>
        /// <returns></returns>
        public List<QuizAttempts> GetMakingTimeForMeQuizAttempts(string userId, int attempt, QuizDetails quizDetails)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userId);
            var latestAttempt = _makingTimeForMeQuizAdapter.GetLatestAttemptByUser(userId);
            List<BsonDocument> result = new List<BsonDocument>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount);
                    var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                    result = _quizAttempt.GetRecords(_makingTimeForMeAttemptsCollection, userAndAttempt);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount - 1);
                        var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                        result = _quizAttempt.GetRecords(_makingTimeForMeAttemptsCollection, userAndAttempt);
                    }

                }

            }
            var maingTimeForMeQuizzes = _makingTimeForMeQuizAdapter.GetMakingTimeForMeQuizzes();

            List<QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("attemptcount", out BsonValue attemptValue);
                item.TryGetValue("questionid", out BsonValue questionidValue);

                var question = maingTimeForMeQuizzes.Where(a => a.id == Common.IntegerNullCheck(questionidValue));
                quizAttempts.Add(new QuizAttempts
                {
                    question = question.Count() == 0 ? "" : question.Select(a => a.question).FirstOrDefault().ToString(CultureInfo.InvariantCulture),
                    answer = Common.StringNullCheck(answerValue),
                    userId = Common.StringNullCheck(useridValue),
                    attempt = Common.IntegerNullCheck(attemptValue),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        /// <summary>
        /// For getting making time for me Quiz details
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attempt"></param>
        /// <param name="quizDetails"></param>
        /// <returns></returns>
        public List<QuizAttempts> GetStoryTellingForImpactQuizAttempts(string userId, int attempt, QuizDetails quizDetails)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userId);
            var latestAttempt = _storyTellingForImpactAdapter.GetLatestAttemptByUser(userId);
            List<BsonDocument> result = new List<BsonDocument>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount);
                    var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                    result = _quizAttempt.GetRecords(_storyTellingAttemptsCollection, userAndAttempt);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount - 1);
                        var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                        result = _quizAttempt.GetRecords(_storyTellingAttemptsCollection, userAndAttempt);
                    }

                }

            }
            var storyTellingForImpactQuizzes = _storyTellingForImpactAdapter.GetStoryTellingForImpactQuizzes();

            List<QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("attemptcount", out BsonValue attemptValue);
                item.TryGetValue("questionid", out BsonValue questionidValue);

                var question = storyTellingForImpactQuizzes.Where(a => a.id == Common.IntegerNullCheck(questionidValue));
                quizAttempts.Add(new QuizAttempts
                {
                    question = question.Count() == 0 ? "" : question.Select(a => a.question).FirstOrDefault().ToString(CultureInfo.InvariantCulture),
                    answer = Common.StringNullCheck(answerValue),
                    userId = Common.StringNullCheck(useridValue),
                    attempt = Common.IntegerNullCheck(attemptValue),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        /// <summary>
        /// For getting learning myth quiz details.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attempt"></param>
        /// <param name="quizDetails"></param>
        /// <returns></returns>
        public List<QuizAttempts> GetLearningMythQuizAttempts(string userId, int attempt, QuizDetails quizDetails)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userId);
            var latestAttempt = _learningMythAdapter.GetLatestAttemptByUser(userId);
            List<BsonDocument> result = new List<BsonDocument>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount);
                    var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                    result = _quizAttempt.GetRecords(_learningMythAttemptsCollection, userAndAttempt);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount - 1);
                        var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                        result = _quizAttempt.GetRecords(_learningMythAttemptsCollection, userAndAttempt);
                    }

                }

            }
            var learningMythQuizzes = _learningMythAdapter.GetLearningMythsQuizzes();

            List<QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("attemptcount", out BsonValue attemptValue);
                item.TryGetValue("questionid", out BsonValue questionidValue);

                var question = learningMythQuizzes.Where(a => a.id == Common.IntegerNullCheck(questionidValue));
                quizAttempts.Add(new QuizAttempts
                {
                    question = question.Count() == 0 ? "" : question.Select(a => a.question).FirstOrDefault().ToString(CultureInfo.InvariantCulture),
                    answer = Common.StringNullCheck(answerValue),
                    userId = Common.StringNullCheck(useridValue),
                    attempt = Common.IntegerNullCheck(attemptValue),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        /// <summary>
        /// For getting GetCulturalObservationQuizAttempts - Pending
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attempt"></param>
        /// <param name="quizDetails"></param>
        /// <returns></returns>
        public List<QuizAttempts> GetCulturalObservationQuizAttempts(string userId, int attempt, QuizDetails quizDetails)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userId);
            var latestAttempt = _culturalObservationAdapter.GetLatestAttemptByUser(userId);
            List<BsonDocument> result = new List<BsonDocument>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount);
                    var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                    result = _quizAttempt.GetRecords(_culturalObservationAttemptsCollection, userAndAttempt);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount - 1);
                        var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                        result = _quizAttempt.GetRecords(_culturalObservationAttemptsCollection, userAndAttempt);
                    }

                }

            }
            var culturalObservationQuizzes = _culturalObservationAdapter.GetCutlturalObservationQuiz();

            List<QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("date", out BsonValue dateValue);
                item.TryGetValue("meetingtitle", out BsonValue meetingTitleValue);
                item.TryGetValue("scoring", out BsonValue scoringValue);
                item.TryGetValue("comments", out BsonValue commentsValue);
                item.TryGetValue("attemptcount", out BsonValue attemptValue);
                item.TryGetValue("questionid", out BsonValue questionidValue);

                var question = culturalObservationQuizzes.Where(a => a.id == Common.IntegerNullCheck(questionidValue));
                quizAttempts.Add(new QuizAttempts
                {
                    question = question.Count() == 0 ? "" : question.Select(a => a.question).FirstOrDefault().ToString(CultureInfo.InvariantCulture),
                    answer = Common.StringNullCheck(answerValue),
                    userId = Common.StringNullCheck(useridValue),
                    date = Common.StringNullCheck(dateValue),
                    meetingTitle = Common.StringNullCheck(meetingTitleValue),
                    scoring = Common.StringNullCheck(scoringValue),
                    comments = Common.StringNullCheck(commentsValue),
                    attempt = Common.IntegerNullCheck(attemptValue),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        /// <summary>
        /// For getting ProductivityZoneQuizAttempts
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="attempt"></param>
        /// <param name="quizDetails"></param>
        /// <returns></returns>
        public List<QuizAttempts> GetProductivityZoneQuizAttempts(string userId, int attempt, QuizDetails quizDetails)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userid", userId);
            var latestAttempt = _productivityZoneQuizAdapter.GetLatestAttemptByUser(userId);
            List<BsonDocument> result = new List<BsonDocument>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount);
                    var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                    result = _quizAttempt.GetRecords(_productivityZoneAttemptsCollection, userAndAttempt);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        var attemptFilter = Builders<BsonDocument>.Filter.Eq("attemptcount", latestAttempt.attemptcount - 1);
                        var userAndAttempt = Builders<BsonDocument>.Filter.And(userFilter, attemptFilter);
                        result = _quizAttempt.GetRecords(_productivityZoneAttemptsCollection, userAndAttempt);
                    }

                }

            }
            var productivityZoneQuizzes = _productivityZoneQuizAdapter.GetProductivityZoneQuizzes();

            List<QuizAttempts> quizAttempts = new List<QuizAttempts>();
            foreach (var item in result)
            {
                item.TryGetValue("answer", out BsonValue answerValue);
                item.TryGetValue("userid", out BsonValue useridValue);
                item.TryGetValue("attemptcount", out BsonValue attemptValue);
                item.TryGetValue("questionid", out BsonValue questionidValue);

                var question = productivityZoneQuizzes.Where(a => a.id == Common.IntegerNullCheck(questionidValue));
                quizAttempts.Add(new QuizAttempts
                {
                    question = question.Count() == 0 ? "" : question.Select(a => a.question).FirstOrDefault().ToString(CultureInfo.InvariantCulture),
                    answer = Common.StringNullCheck(answerValue),
                    userId = Common.StringNullCheck(useridValue),
                    attempt = Common.IntegerNullCheck(attemptValue),
                    type = quizDetails.type
                });
            }

            return quizAttempts;
        }

        public List<QuizAttempts> GetReflectionToolQuizAttempts(string userId, int attempt, QuizDetails quizDetails)
        {
            var reflectionToolQuizzes = _reflectionToolAdapter.GetReflectionToolQuestions();
            var latestAttempt = _reflectionToolAdapter.GetLatestAttemptByUser(userId);
            List<ReflectionToolQuizAttempt> result = new List<ReflectionToolQuizAttempt>();
            if (latestAttempt != null)
            {
                if (attempt == 1)
                {
                    result= _reflectionToolAdapter.GetReflectionToolAttempts(userId, latestAttempt.attemptcount);
                }
                else
                {
                    if (latestAttempt.attemptcount > 1)
                    {
                        _reflectionToolAdapter.GetReflectionToolAttempts(userId, latestAttempt.attemptcount-1);
                    }

                }

            }

            List<QuizAttempts> quizAttempts = new List<QuizAttempts>();

            if (result != null)
            {
                foreach (var quizAttempt in result)
                {
                    QuizAttempts attempts = new QuizAttempts
                    {
                        question = reflectionToolQuizzes.FirstOrDefault(q => q.id == quizAttempt.questionid)?.question,
                        answer = quizAttempt.answer,
                        userId = quizAttempt.userid,
                        selectedoptions = string.Join(",",quizAttempt.selectedoptions),
                        attempt = quizAttempt.attemptcount,
                        type = quizDetails.type
                    };
                    quizAttempts.Add(attempts);
                }
            }

            return quizAttempts;
        }

    }
}
