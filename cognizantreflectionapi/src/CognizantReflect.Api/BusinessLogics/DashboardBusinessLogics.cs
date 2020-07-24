using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.Dashboard;
using CognizantReflect.Api.Models.FeedbackService;
using CognizantReflect.Api.Models.UserService;

namespace CognizantReflect.Api.BusinessLogics
{
    internal class DashboardBusinessLogics : IDashboardBusinessLogics
    {
        private readonly IDashboardAdapter _dashboardAdapter;
        private readonly IUserAdapter _userAdapter;
        private readonly IFeedbackAdapter _feedbackAdapter;

        public DashboardBusinessLogics(IDashboardAdapter dashboardAdapter,IUserAdapter userAdapter,IFeedbackAdapter feedbackAdapter)
        {
            _dashboardAdapter = dashboardAdapter;
            _userAdapter = userAdapter;
            _feedbackAdapter = feedbackAdapter;
        }

        public int[][] GetDetailsForScoreGraphChart(string userid)
        {

            int[][] scoreListForTwoAttempts = new int[2][];

            int[] latestAttempt = new int[4];

            int[] previousAttempt = new int[4];

            var curiousAttemptCount = _dashboardAdapter.GetAttemptCountForCuriousQuiz(userid);

            if (curiousAttemptCount < 1)
            {
                latestAttempt[0] = 0;
                previousAttempt[0] = 0;
            }
            else if (curiousAttemptCount == 1)
            {
                latestAttempt[0] = _dashboardAdapter.GetCuriousQuizScoreOfUser(userid, curiousAttemptCount);
                previousAttempt[0] = 0;
            }
            else
            {
                latestAttempt[0] = _dashboardAdapter.GetCuriousQuizScoreOfUser(userid, curiousAttemptCount);
                previousAttempt[0] = _dashboardAdapter.GetCuriousQuizScoreOfUser(userid, curiousAttemptCount - 1);
            }

            var growthMindsetAttemptCount = _dashboardAdapter.GetAttemptCountForGrowthMindsetQuiz(userid);

            if (growthMindsetAttemptCount < 1)
            {
                latestAttempt[1] = 0;
                previousAttempt[1] = 0;
            }
            else if (growthMindsetAttemptCount == 1)
            {
                latestAttempt[1] = _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(userid, growthMindsetAttemptCount);
                previousAttempt[1] = 0;
            }
            else
            {
                latestAttempt[1] = _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(userid, growthMindsetAttemptCount);
                previousAttempt[1] = _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(userid, growthMindsetAttemptCount - 1);
            }

            var makingTimeAttemptCount = _dashboardAdapter.GetAttemptCountForMakingTimeQuiz(userid);

            if (makingTimeAttemptCount < 1)
            {
                latestAttempt[2] = 0;
                previousAttempt[2] = 0;
            }
            else if (makingTimeAttemptCount == 1)
            {
                latestAttempt[2] = _dashboardAdapter.GetMakingTimeQuizScoreOfUser(userid, makingTimeAttemptCount);
                previousAttempt[2] = 0;
            }
            else
            {
                latestAttempt[2] = _dashboardAdapter.GetMakingTimeQuizScoreOfUser(userid, makingTimeAttemptCount);
                previousAttempt[2] = _dashboardAdapter.GetMakingTimeQuizScoreOfUser(userid, makingTimeAttemptCount - 1);
            }

            var cultureObservationAttemptCount = _dashboardAdapter.GetAttemptCountForCultureObservationQuiz(userid);

            if (cultureObservationAttemptCount < 1)
            {
                latestAttempt[3] = 0;
                previousAttempt[3] = 0;
            }
            else if (cultureObservationAttemptCount == 1)
            {
                latestAttempt[3] = _dashboardAdapter.GetCultureObservationQuizScoreOfUser(userid, cultureObservationAttemptCount);
                previousAttempt[3] = 0;
            }
            else
            {
                latestAttempt[3] = _dashboardAdapter.GetCultureObservationQuizScoreOfUser(userid, cultureObservationAttemptCount);
                previousAttempt[3] = _dashboardAdapter.GetCultureObservationQuizScoreOfUser(userid, cultureObservationAttemptCount - 1);
            }

            scoreListForTwoAttempts[0] = latestAttempt;
            scoreListForTwoAttempts[1] = previousAttempt;

            return scoreListForTwoAttempts;

        }

        public int[][] GetDetailsForScoreGraphChart()
        {

            int[][] scoreListForTwoAttempts = new int[2][];

            int[] latestAttempt = new int[] { 0, 0, 0, 0 };

            int[] previousAttempt = new int[] { 0, 0, 0, 0 };

            List<UserDetails> userList = _userAdapter.GetUserList();

            foreach (var user in userList)
            {
                var curiousAttemptCount = _dashboardAdapter.GetAttemptCountForCuriousQuiz(user.UserId);

                if (curiousAttemptCount == 1)
                {
                    latestAttempt[0] += _dashboardAdapter.GetCuriousQuizScoreOfUser(user.UserId, curiousAttemptCount);
                }
                else if (curiousAttemptCount > 1)
                {
                    latestAttempt[0] += _dashboardAdapter.GetCuriousQuizScoreOfUser(user.UserId, curiousAttemptCount);
                    previousAttempt[0] += _dashboardAdapter.GetCuriousQuizScoreOfUser(user.UserId, curiousAttemptCount - 1);
                }

                var growthMindsetAttemptCount = _dashboardAdapter.GetAttemptCountForGrowthMindsetQuiz(user.UserId);

                if (growthMindsetAttemptCount == 1)
                {
                    latestAttempt[1] += _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(user.UserId, growthMindsetAttemptCount);
                }
                else if (growthMindsetAttemptCount > 1)
                {
                    latestAttempt[1] += _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(user.UserId, growthMindsetAttemptCount);
                    previousAttempt[1] += _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(user.UserId, growthMindsetAttemptCount - 1);
                }

                var makingTimeAttemptCount = _dashboardAdapter.GetAttemptCountForMakingTimeQuiz(user.UserId);

                if (makingTimeAttemptCount == 1)
                {
                    latestAttempt[2] += _dashboardAdapter.GetMakingTimeQuizScoreOfUser(user.UserId, makingTimeAttemptCount);
                }
                else if (makingTimeAttemptCount > 1)
                {
                    latestAttempt[2] += _dashboardAdapter.GetMakingTimeQuizScoreOfUser(user.UserId, makingTimeAttemptCount);
                    previousAttempt[2] += _dashboardAdapter.GetMakingTimeQuizScoreOfUser(user.UserId, makingTimeAttemptCount - 1);
                }

                var cultureObservationAttemptCount = _dashboardAdapter.GetAttemptCountForCultureObservationQuiz(user.UserId);

                if (cultureObservationAttemptCount == 1)
                {
                    latestAttempt[3] += _dashboardAdapter.GetCultureObservationQuizScoreOfUser(user.UserId, cultureObservationAttemptCount);
                }
                else if (cultureObservationAttemptCount > 1)
                {
                    latestAttempt[3] += _dashboardAdapter.GetCultureObservationQuizScoreOfUser(user.UserId, cultureObservationAttemptCount);
                    previousAttempt[3] += _dashboardAdapter.GetCultureObservationQuizScoreOfUser(user.UserId, cultureObservationAttemptCount - 1);
                }

            }

            scoreListForTwoAttempts[0] = latestAttempt;
            scoreListForTwoAttempts[1] = previousAttempt;

            return scoreListForTwoAttempts;

        }

        public QuizAttemptCounts GetQuizAttemptCountsByUser(string userid)
        {
            return new QuizAttemptCounts
            {
                CuriosityQuizAttemptCount = _dashboardAdapter.GetAttemptCountForCuriousQuiz(userid),
                GrowthMindsetAttemptCount = _dashboardAdapter.GetAttemptCountForGrowthMindsetQuiz(userid),
                MakingTimeForMeAttemptCount = _dashboardAdapter.GetAttemptCountForMakingTimeQuiz(userid),
                CultureObservationAttemptCount = _dashboardAdapter.GetAttemptCountForCultureObservationQuiz(userid)
            };

        }

        public QuizAttemptCounts GetTotalQuizAttemptCounts()
        {
            var curiousAttempt = _dashboardAdapter.GetTotalRecordsOfCuriosityQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var growthMindsetAttempt = _dashboardAdapter.GetTotalRecordsOfGrowthMindsetQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var makingTimeAttempt = _dashboardAdapter.GetTotalRecordsOfMakingTimeForMeQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var cultureObservationAttempt = _dashboardAdapter.GetTotalRecordsOfCultureObservationQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));



            return new QuizAttemptCounts
            {
                CuriosityQuizAttemptCount = curiousAttempt ?? 0,
                GrowthMindsetAttemptCount = growthMindsetAttempt ?? 0,
                MakingTimeForMeAttemptCount = makingTimeAttempt ?? 0,
                CultureObservationAttemptCount = cultureObservationAttempt ?? 0
            };

        }

        public int GetPercentageOfCompletionByUser(string userid)
        {
            var attemptCount = _dashboardAdapter.GetAttemptedQuizCountByUser(userid);

            return Math.Abs((attemptCount * 100) / 10 );
        }

        public int GetOverallPercentageOfQuizCompletion()
        {
            List<UserDetails> userList = _userAdapter.GetUserList();
            var attemptCount = 0;
            var totalNumberOfQuizToAttemptPerUser = userList.Count * 10;

            foreach (var userid in userList)
            {
                attemptCount += _dashboardAdapter.GetAttemptedQuizCountByUser(userid.UserId);
            }


            return Math.Abs((attemptCount * 100/ totalNumberOfQuizToAttemptPerUser));
        }

        public int[] GetQuizAttemptHistoryDetailsByUser(string userid)
        {
            var attemptCounts = new List<int>
            {
                _dashboardAdapter.GetAttemptCountForBlindSpotQuiz(userid),
                _dashboardAdapter.GetAttemptCountForProductivityZoneQuiz(userid),
                _dashboardAdapter.GetAttemptCountForContinuousLearningQuiz(userid),
                _dashboardAdapter.GetAttemptCountForReflectionToolQuiz(userid),
                _dashboardAdapter.GetAttemptCountForStoryTellingForImpactQuiz(userid),
                _dashboardAdapter.GetAttemptCountForLearningMythsQuiz(userid)

            };


            return attemptCounts.ToArray();
        }

        public int[] GetQuizAttemptHistoryDetails()
        {
            var blindSpotAttempt = _dashboardAdapter.GetTotalRecordsOfBlindSpotQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var continuousLearningAttempt = _dashboardAdapter.GetTotalRecordsOfContinuousLearningQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var learningMythsAttempt = _dashboardAdapter.GetTotalRecordsOfLearningMythsQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var productivityZoneAttempt = _dashboardAdapter.GetTotalRecordsOfProductivityZoneQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var reflectionToolAttempt = _dashboardAdapter.GetTotalRecordsOfReflectionToolQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

            var storyTellingAttempt = _dashboardAdapter.GetTotalRecordsOfStoryTellingQuiz()?
                .GroupBy(s => new { s.userid })
                .Sum(k => k.Max(s => s.attemptcount));

           var attemptCounts = new List<int>
            {
                blindSpotAttempt??0,
                productivityZoneAttempt??0,
                continuousLearningAttempt??0,
                reflectionToolAttempt??0,
                storyTellingAttempt??0,
                learningMythsAttempt??0
            };

           return attemptCounts.ToArray();
        }

        public int[] GetContinuousLearningDetails(string userid)
        {
            List<int> continuousLearningCounts;

            if (userid == "")
            {
                continuousLearningCounts = new List<int>
                {
                    _dashboardAdapter.GetContinuousLearningYesCount(),
                    _dashboardAdapter.GetContinuousLearningSomewhatCount(),
                    _dashboardAdapter.GetContinuousLearningNoCount()
                };
            }
            else
            {
                continuousLearningCounts = new List<int>
                {
                    _dashboardAdapter.GetContinuousLearningYesCount(userid),
                    _dashboardAdapter.GetContinuousLearningSomewhatCount(userid),
                    _dashboardAdapter.GetContinuousLearningNoCount(userid)
                };

            }

            return continuousLearningCounts.ToArray();
        }

        public List<QuizResultAndTimes> GetCuriosityResultAndTimes(string userid)
        {

            var excellent = 0;
            var medium = 0;
            var low = 0;

            var attemptCount = _dashboardAdapter.GetAttemptCountForCuriousQuiz(userid);

            for (int i = 1; i <= attemptCount; i++)
            {
                var scoredInCuriosityQuiz = _dashboardAdapter.GetCuriousQuizScoreOfUser(userid, i);
                if (scoredInCuriosityQuiz >= 10)
                    excellent += 1;
                else if (scoredInCuriosityQuiz >= 5)
                    medium += 1;
                else
                {
                    low += 1;
                }

            }

            return new List<QuizResultAndTimes>
            {
                new QuizResultAndTimes
                {
                    statement =
                        "You are highly curious and can spread your curiosity to others and have a high need for cognition.",
                    times = excellent
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You are curious and can continue to grow in your curiosity and your need for cognition in typical to your peers.",
                    times = medium
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You are on a curiosity journey and will continue to grow and work on developing your need for cognition.",
                    times = low
                }

            };
        }

        public List<QuizResultAndTimes> GetGrowthMindsetResultAndTimes(string userid)
        {

            var excellent = 0;
            var medium = 0;
            var low = 0;



            var attemptCount = _dashboardAdapter.GetAttemptCountForGrowthMindsetQuiz(userid);

            for (int i = 1; i <= attemptCount; i++)
            {
                var scoredInGrowthMindsetQuiz = _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(userid, i);
                if (scoredInGrowthMindsetQuiz >= 7)
                    excellent += 1;
                else if (scoredInGrowthMindsetQuiz >= 4)
                    medium += 1;
                else
                {
                    low += 1;
                }

            }

            return new List<QuizResultAndTimes>
            {
                new QuizResultAndTimes
                {
                    statement =
                        "You are using a growth mindset more often than a fixed mindset.You may also consider mentoring others.",
                    times = excellent
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You regularly are using a growth mindset, but you have the opportunity to use a growth mindset more often.  ",
                    times = medium
                },
                new QuizResultAndTimes
                {
                    statement =
                        "This is a great time for you to practice using a growth mindset every day.",
                    times = low
                }

            };
        }

        public List<QuizResultAndTimes> GetMakingTimeResultAndTimes(string userid)
        {

            var excellent = 0;
            var medium = 0;
            var low = 0;



            var attemptCount = _dashboardAdapter.GetAttemptCountForMakingTimeQuiz(userid);

            for (int i = 1; i <= attemptCount; i++)
            {
                var scoredInMakingTimeQuiz = _dashboardAdapter.GetMakingTimeQuizScoreOfUser(userid, i);
                if (scoredInMakingTimeQuiz > 40)
                    excellent += 1;
                else if (scoredInMakingTimeQuiz > 20)
                    medium += 1;
                else
                {
                    low += 1;
                }

            }

            return new List<QuizResultAndTimes>
            {
                new QuizResultAndTimes
                {
                    statement =
                        "You manage your time very effectively. Keep up the good work.",
                    times = excellent
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You are good at managing some of your tasks and projects, but there is room for improvement.",
                    times = medium
                },
                new QuizResultAndTimes
                {
                    statement =
                        "Now is the time to examine how you work and manage your time.",
                    times = low
                }

            };
        }

        public List<QuizResultAndTimes> GetCuriosityResultAndTimes()
        {

            var excellent = 0;
            var medium = 0;
            var low = 0;

            List<UserDetails> userList = _userAdapter.GetUserList();

            foreach (var userid in userList)
            {

                var attemptCount = _dashboardAdapter.GetAttemptCountForCuriousQuiz(userid.UserId);

                for (int i = 1; i <= attemptCount; i++)
                {
                    var scoredInCuriosityQuiz = _dashboardAdapter.GetCuriousQuizScoreOfUser(userid.UserId, i);
                    if (scoredInCuriosityQuiz >= 10)
                        excellent += 1;
                    else if (scoredInCuriosityQuiz >= 5)
                        medium += 1;
                    else
                    {
                        low += 1;
                    }

                }
            }

            return new List<QuizResultAndTimes>
            {
                new QuizResultAndTimes
                {
                    statement =
                        "You are highly curious and can spread your curiosity to others and have a high need for cognition.",
                    times = excellent
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You are curious and can continue to grow in your curiosity and your need for cognition in typical to your peers.",
                    times = medium
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You are on a curiosity journey and will continue to grow and work on developing your need for cognition.",
                    times = low
                }

            };
        }

        public List<QuizResultAndTimes> GetGrowthMindsetResultAndTimes()
        {

            var excellent = 0;
            var medium = 0;
            var low = 0;

            List<UserDetails> userList = _userAdapter.GetUserList();

            foreach (var userid in userList)
            {
                var attemptCount = _dashboardAdapter.GetAttemptCountForGrowthMindsetQuiz(userid.UserId);

                for (int i = 1; i <= attemptCount; i++)
                {
                    var scoredInGrowthMindsetQuiz = _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser(userid.UserId, i);
                    if (scoredInGrowthMindsetQuiz >= 7)
                        excellent += 1;
                    else if (scoredInGrowthMindsetQuiz >= 4)
                        medium += 1;
                    else
                    {
                        low += 1;
                    }

                }
            }

            return new List<QuizResultAndTimes>
            {
                new QuizResultAndTimes
                {
                    statement =
                        "You are using a growth mindset more often than a fixed mindset.You may also consider mentoring others.",
                    times = excellent
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You regularly are using a growth mindset, but you have the opportunity to use a growth mindset more often.  ",
                    times = medium
                },
                new QuizResultAndTimes
                {
                    statement =
                        "This is a great time for you to practice using a growth mindset every day.",
                    times = low
                }

            };
        }

        public List<QuizResultAndTimes> GetMakingTimeResultAndTimes()
        {

            var excellent = 0;
            var medium = 0;
            var low = 0;

            List<UserDetails> userList = _userAdapter.GetUserList();

            foreach (var userid in userList)
            {
                var attemptCount = _dashboardAdapter.GetAttemptCountForMakingTimeQuiz(userid.UserId);

                for (int i = 1; i <= attemptCount; i++)
                {
                    var scoredInMakingTimeQuiz = _dashboardAdapter.GetMakingTimeQuizScoreOfUser(userid.UserId, i);
                    if (scoredInMakingTimeQuiz > 40)
                        excellent += 1;
                    else if (scoredInMakingTimeQuiz > 20)
                        medium += 1;
                    else
                    {
                        low += 1;
                    }

                }
            }

            return new List<QuizResultAndTimes>
            {
                new QuizResultAndTimes
                {
                    statement =
                        "You manage your time very effectively. Keep up the good work.",
                    times = excellent
                },
                new QuizResultAndTimes
                {
                    statement =
                        "You are good at managing some of your tasks and projects, but there is room for improvement.",
                    times = medium
                },
                new QuizResultAndTimes
                {
                    statement =
                        "Now is the time to examine how you work and manage your time.",
                    times = low
                }

            };
        }

        public List<UserDetails> GetUserDetails(string userId="")
        {
            return _userAdapter.GetUserList(userId);
        }

        public UserDetails GetLoggedUserDetails(string userId = "",string emailId="")
        {
            return _userAdapter.GetloggedUser(userId, emailId);
        }

        public List<UserDetails> GetUsersByRole(string role)
        {
            return _userAdapter.GetUsersByRole(role);
        }

        public void StoreFeedbackQuestions(Feedback feedback)
        {
            _feedbackAdapter.SaveFeedbackQuestion(feedback);
        }

        public List<Feedback> GetFeedbackDetailsForAdmin()
        {
            return _feedbackAdapter.GetFeedbackDetailsForAdmin();
        }

        public void SaveFeedbackReply(FeedbackReply feedbackReply)
        {

            _feedbackAdapter.SaveFeedbackReply(feedbackReply);
        }

        public void UpdateOrAddFeedbacksByAdmin(List<Feedback> feedbacks)
        {
            
            _feedbackAdapter.UpdateOrAddFeedbacksByAdmin(feedbacks);

        }

        public void UpdateFeedbackStatus(long id)
        {
            _feedbackAdapter.UpdateFeedbackStatus(id);
        }

        public void SaveBlindSpotNotification(BlindSpotNotification blindSpotNotification)
        {
            _feedbackAdapter.SaveBlindSpotNotification(blindSpotNotification);
        }

        public List<Feedback> GetNotificationListForUser(string userid, int start, int count)
        {
           return _feedbackAdapter.GetNotificationListForUser(userid, start, count);
        }

        public List<Feedback> GetAdminComments(string userid)
        {
            return _feedbackAdapter.GetAdminComments(userid);
        }

        public long GetNotificationCount(string userid)
        {
            return _feedbackAdapter.GetNotificationsCount(userid);
        }

        public void DeleteFeedback(long id)
        {
            _feedbackAdapter.DeleteFeedback(id);
        }

    }
}
