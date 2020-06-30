using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using CognizantReflect.Api.Models.FeedbackService;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class BlindSpotBusinessLogics : IBlindSpotBusinessLogics
    {
        private readonly IBlindSpotAdapter _blindSpotAdapter;
        private readonly IFeedbackAdapter _feedbackAdapter;

        public BlindSpotBusinessLogics(IBlindSpotAdapter blindSpotAdapter,IFeedbackAdapter feedbackAdapter)
        {
            _blindSpotAdapter = blindSpotAdapter;
            _feedbackAdapter = feedbackAdapter;
        }

        public BlindSpotQuizQuestions GetBlindSpotQuizQuestions()
        {
            return _blindSpotAdapter.GetBlindSpotQuizQuestions();
        }

        public void SaveBlindSpotUserResponse(BlindSpotQuizAttempts response)
        {
            response.id = _blindSpotAdapter.GetLastInsertedAttemptId() + 1;
            response.attemptcount = _blindSpotAdapter.GetLatestAttemptByUser(response.userid)?.attemptcount + 1 ?? 1;
            _blindSpotAdapter.SaveBlindSpotUserResponse(response);

            var lastRecordCount = _blindSpotAdapter.GetLastInsertedCoWorkerReply();

            foreach (var coWorker in response.selectedcoWorkers)
            {
                lastRecordCount++;
                BlindSpotCoWorkerReply coWorkerReply = new BlindSpotCoWorkerReply
                {
                    id = lastRecordCount,
                    attemptid = response.id,
                    userid = coWorker,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    selectedadjectives = new string[] { }
                };

                _blindSpotAdapter.SaveBlindSpotCoWorkerResponse(coWorkerReply);

            }

            BlindSpotNotification notification = new BlindSpotNotification() { userid = response.userid, coworkerid = response.selectedcoWorkers.ToList()};
            _feedbackAdapter.SendNotification(notification);
        }

        public void SaveBlindSpotCoWorkerReply(BlindSpotCoWorkerReply response)
        {
            _blindSpotAdapter.SaveBlindSpotCoWorkerResponse(response);
        }

        public void UpdateBlindSpotCoWorkerReply(BlindSpotCoWorkerReply response)
        {
            _blindSpotAdapter.UpdateBlindSpotCoWorkerResponse(response);
        }

        public BlindSpotQuizResult ShowBlindSpotQuizResult(string user)
        {
            BlindSpotQuizResult result = new BlindSpotQuizResult();

            List<string> arena = new List<string>();//adjectives both user and coworker selects
            List<string> facade = new List<string>();//adjectives only user selects
            List<string> blindSpot = new List<string>();//adjectives only coworker selects
            List<string> unknown = new List<string>();//adjectives no body selects

            var getAllAdjectives = _blindSpotAdapter.GetBlindSpotQuizQuestions();

            var latestUserAttempt = _blindSpotAdapter.GetLatestAttemptByUser(user);

            if (latestUserAttempt != null)
            {
                var coWorkerReplies = _blindSpotAdapter.GetCoWorkerResponsesByAttempt(latestUserAttempt.id);

                foreach (var userSelectedAdjective in latestUserAttempt.selectedadjectives)
                {

                    var flag = false;
                    foreach (var reply in coWorkerReplies)
                    {

                        if (reply.selectedadjectives.Contains(userSelectedAdjective))
                        {
                            arena.Add(userSelectedAdjective);
                            flag = true;
                            break;
                        }

                    }
                    if (!flag)
                        facade.Add(userSelectedAdjective);
                }

                foreach (var reply in coWorkerReplies)
                {
                    foreach (var adjective in reply.selectedadjectives)
                    {
                        if (!arena.Contains(adjective))
                        {
                            if (!blindSpot.Contains(adjective))
                                blindSpot.Add(adjective);
                        }

                    }
                }

                foreach (var availableAdjective in getAllAdjectives.adjectives)
                {
                    if (!arena.Contains(availableAdjective) && !facade.Contains(availableAdjective) && !blindSpot.Contains(availableAdjective))
                        unknown.Add(availableAdjective);
                }

                result.attemptid = latestUserAttempt.id;
                result.facade = facade.ToArray();
                result.blindspot = blindSpot.ToArray();
                result.arena = arena.ToArray();
                result.unknown = unknown.ToArray();
            }



            return result;
        }

        public List<BlindSpotCoWorkerReply> GetBlindSpotCoWorkerRequest(string userid)
        {
            return _blindSpotAdapter.GetDataForCoWorkerReply(userid);
        }
    }
}
