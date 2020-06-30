using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using CognizantReflect.Api.Models.CuriosityQuiz;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;

namespace CognizantReflect.Api.Helpers
{
    public static class SampleData
    {
        public static List<CuriousQuiz> CuriousityQuestions()
        {
            return new List<CuriousQuiz>
            {
                new CuriousQuiz {id= 1, question = "I would prefer complex to simple problems.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 2, question = "I like to have the responsibility of handling a situation that requires a lot of thinking.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 3, question = "I usually end up deliberating about issues even when they do not affect me personally.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture) },
                new CuriousQuiz {id= 4, question = "I would prefer complex to simple problems.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 5, question = "I like to have the responsibility of handling a situation that requires a lot of thinking.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 6, question = "I usually end up deliberating about issues even when they do not affect me personally.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture) },
                new CuriousQuiz {id= 7, question = "I would prefer complex to simple problems.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 8, question = "I like to have the responsibility of handling a situation that requires a lot of thinking.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 9, question = "I usually end up deliberating about issues even when they do not affect me personally.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture) },
                new CuriousQuiz {id= 10, question = "I would prefer complex to simple problems.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 11, question = "I like to have the responsibility of handling a situation that requires a lot of thinking.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new CuriousQuiz {id= 12, question = "I usually end up deliberating about issues even when they do not affect me personally.",answer = true,score = 1,updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture) }
            };
        }
        public static List<MakingTimeForMeQuiz> MakingTimeForMeQuizzes()
        {
            return new List<MakingTimeForMeQuiz>
            {
                new MakingTimeForMeQuiz { id = 1, question = "I would prefer complex to simple problems.",scores = new Score {always=0,often=1,sometimes=2,rarely=3,never=4}},
                new MakingTimeForMeQuiz { id = 2, question= "I like to have the responsibility of handling a situation that requires a lot of thinking.",scores = new Score { always= 4,often= 3,sometimes= 2,rarely= 1,never= 0} },
                new MakingTimeForMeQuiz { id = 3, question= "I usually end up deliberating about issues even when they do not affect me personally.",scores = new Score { always= 0,often= 1,sometimes= 2,rarely= 3,never= 4} },
                new MakingTimeForMeQuiz { id = 4, question= "I would prefer complex to simple problems.",scores = new Score { always= 4,often= 3,sometimes= 2,rarely= 1,never= 0} },
                new MakingTimeForMeQuiz { id = 5, question= "I like to have the responsibility of handling a situation that requires a lot of thinking.",scores = new Score { always= 0,often= 1,sometimes= 2,rarely= 3,never= 4} },
                new MakingTimeForMeQuiz { id = 6, question= "I usually end up deliberating about issues even when they do not affect me personally.",scores = new Score { always= 4,often= 3,sometimes= 2,rarely= 1,never= 0} },
                new MakingTimeForMeQuiz { id = 7, question= "I would prefer complex to simple problems.",scores = new Score { always= 0,often= 1,sometimes= 2,rarely= 3,never= 4} },
                new MakingTimeForMeQuiz { id = 8, question= "I like to have the responsibility of handling a situation that requires a lot of thinking.",scores = new Score { always= 4,often= 3,sometimes= 2,rarely= 1,never= 0} },
                new MakingTimeForMeQuiz { id = 9, question= "I usually end up deliberating about issues even when they do not affect me personally.",scores = new Score { always= 0,often= 1,sometimes= 2,rarely= 3,never= 4} },
                new MakingTimeForMeQuiz { id = 10, question= "I would prefer complex to simple problems.",scores = new Score { always= 4,often= 3,sometimes= 2,rarely= 1,never= 0} },
                new MakingTimeForMeQuiz { id = 11, question= "I like to have the responsibility of handling a situation that requires a lot of thinking.",scores = new Score { always= 0,often= 1,sometimes= 2,rarely= 3,never= 4} },
                new MakingTimeForMeQuiz { id = 12, question= "I usually end up deliberating about issues even when they do not affect me personally.",scores = new Score { always= 4,often= 3,sometimes= 2,rarely= 1,never= 0} }
            };
        }

        public static List<GrowthMindsetQuiz> GrowthMindsetQuizzes()
        {
            return new List<GrowthMindsetQuiz>
            {
                new GrowthMindsetQuiz {id =1,question="Did you challenge yourself today?",answer=true},
                new GrowthMindsetQuiz {id =2,question="Did you reflect on a mistake you learned from this week?",answer=true},
                new GrowthMindsetQuiz {id =3,question="Did you plan differently to make things work better?",answer=true},
                new GrowthMindsetQuiz {id =4,question="Have you listed what you what to learn next?",answer=true},
                new GrowthMindsetQuiz {id =5,question="Do you ask for honest feedback?",answer=true},
                new GrowthMindsetQuiz {id =6,question="Did you work as hard as you could have?",answer=true},
                new GrowthMindsetQuiz {id =7,question="If it was easy, did you make it more challenging?",answer=true},
                new GrowthMindsetQuiz {id =8,question="Did you hold yourself to high expectations?",answer=true},
                new GrowthMindsetQuiz {id =9,question="Did you ask for help if you needed it?",answer=true},
                new GrowthMindsetQuiz {id =10,question="Can you identify errors you eliminated?",answer=true},
                new GrowthMindsetQuiz {id =11,question="Have you noticed someone else using a fixed mindset?",answer=true},
                new GrowthMindsetQuiz {id =12,question="Have you coached someone using a fixed mindset?",answer=true}
            };
        }

        public static List<StoryTellingForImpactQuiz> StoryTellingForImpactQuizzes()
        {
            return new List<StoryTellingForImpactQuiz>
            {
                 new StoryTellingForImpactQuiz{id= 1, question = "It is okay to exaggerate facts in a story to make a bigger impact on the audience",answer = "true", statement="False ",type="mc2", options=new Optionss{ a="True",b="False"}},
            new StoryTellingForImpactQuiz{id= 2, question = "Stories should be based on all of the following except= ",answer = "What you hope to experience", statement="b.  You do not want to tell a story on what you  hope to experience.",type="mc4",options = new Optionss {a= "What you’ve experienced",
                b= "What you hope to experience",
                c=  "What someone else experienced",
                d=  "A combination of what you and someone else experienced"
                }},
            new StoryTellingForImpactQuiz{id= 3, question = "It is okay to exaggerate facts in a story to make a bigger impact on the audience",answer = "true", statement="False ",type="mc2", options=new Optionss{ a="True",b="False"}},
            new StoryTellingForImpactQuiz{id= 4, question = "Stories should be based on all of the following except= ",answer = "What you hope to experience", statement="b.  You do not want to tell a story on what you  hope to experience.",type="mc4",options=new Optionss{a= "What you’ve experienced",
                b= "What you hope to experience",
                c=  "What someone else experienced",
                d=  "A combination of what you and someone else experienced"
                }},
            new StoryTellingForImpactQuiz{id= 5, question = "It is okay to exaggerate facts in a story to make a bigger impact on the audience",answer = "true", statement="False ",type="mc2", options=new Optionss{ a="True",b="False"}}

            };
        }


        public static List<CuriousQuizAttempts> CuriosityResponses()
        {
            return new List<CuriousQuizAttempts>
            {
                new CuriousQuizAttempts{id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 4,questionid = 4,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 5,questionid = 5,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 6,questionid = 6,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 7,questionid = 7,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 8,questionid = 8,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 9,questionid = 9,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 10,questionid = 10,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 11,questionid = 11,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 12,questionid = 12,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 13,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 14,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 15,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 16,questionid = 4,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 17,questionid = 5,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 18,questionid = 6,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                 new CuriousQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
                new CuriousQuizAttempts{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer=true},
            };
        }

        public static List<GrowthMindsetQuizAttempts> GrowthMindsetResponses()
        {
            return new List<GrowthMindsetQuizAttempts>
            {
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 1, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 2, questionid = 2, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 3, questionid = 3, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 4, questionid = 4, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 5, questionid = 5, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 6, questionid = 6, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 7, questionid = 7, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 8, questionid = 8, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 9, questionid = 9, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 10, questionid = 10, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 11, questionid = 11, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 12, questionid = 12, userid = "Hamid", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 13, questionid = 1, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 14, questionid = 2, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 15, questionid = 3, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 16, questionid = 4, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 17, questionid = 5, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 18, questionid = 6, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 19, questionid = 7, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 20, questionid = 8, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 21, questionid = 9, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 22, questionid = 10, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 23, questionid = 11, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 24, questionid = 12, userid = "Hamid", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 25, questionid = 1, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 26, questionid = 2, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 27, questionid = 3, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 28, questionid = 4, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 29, questionid = 5, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 6, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 7, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 8, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 9, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 10, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 11, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 12, userid = "Hamid", attemptcount = 3,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 1, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 2, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 3, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 4, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 5, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 6, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 7, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 8, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 9, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 10, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 11, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 12, userid = "Hashim", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 1, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 2, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 3, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 4, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 5, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 6, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 7, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 8, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 9, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 10, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 11, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 12, userid = "Hashim", attemptcount = 2,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 1, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 2, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 3, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 4, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 5, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 6, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 7, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 8, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 9, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 10, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 11, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
                new GrowthMindsetQuizAttempts
                {
                    id = 1, questionid = 12, userid = "Anuth", attemptcount = 1,
                    attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture), score = 1, answer = true
                },
            };
        }

        public static List<MakingTimeForMeQuizAttempts> MakingTimeForMeResponses()
        {
            return new List<MakingTimeForMeQuizAttempts>
            {
                new MakingTimeForMeQuizAttempts(){id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 4,questionid = 4,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 5,questionid = 5,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 6,questionid = 6,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 7,questionid = 7,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 8,questionid = 8,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 9,questionid = 9,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 10,questionid = 10,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 11,questionid = 11,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 12,questionid = 12,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 13,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 14,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 15,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 16,questionid = 4,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 17,questionid = 5,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 18,questionid = 6,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=3,answer="always"},
                 new MakingTimeForMeQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=4,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
                new MakingTimeForMeQuizAttempts{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,answer="always"},
            };
        }

        public static List<CultureObservationToolQuizAttempts> CultureObservationToolResponses()
        {
            return new List<CultureObservationToolQuizAttempts>
            {
                 new CultureObservationToolQuizAttempts(){id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 4,questionid = 4,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 5,questionid = 5,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 6,questionid = 6,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 7,questionid = 7,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 8,questionid = 8,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 9,questionid = 9,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 10,questionid = 10,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 11,questionid = 11,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 12,questionid = 12,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 13,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 14,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 15,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 16,questionid = 4,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 17,questionid = 5,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 18,questionid = 6,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                 new CultureObservationToolQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
                new CultureObservationToolQuizAttempts{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),score=1,comments = "nothing",date = DateTime.Now.ToString(CultureInfo.InvariantCulture),meetingtitle = "some meeting"},
            };
        }

        public static List<BlindSpotQuizAttempts> BlindSpotQuizResponses()
        {
            return new List<BlindSpotQuizAttempts>
            {
               new BlindSpotQuizAttempts{id = 1,selectedcoWorkers = new []{"Hamid","Hashim","Arjit"},selectedadjectives = new string[]{"able","accepting","adaptable","bold","brave","calm"},userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),status="active"},
               new BlindSpotQuizAttempts{id = 2,selectedcoWorkers = new []{"Hamid","Hashim","Arjit"},selectedadjectives = new string[]{"able","accepting","adaptable","bold","brave","calm"},userid = "Anuth",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),status="active"},
                new BlindSpotQuizAttempts{id = 3,selectedcoWorkers = new []{"Hamid","Hashim","Arjit"},selectedadjectives = new string[]{"able","accepting","adaptable","bold","brave","calm"},userid = "Anuth",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),status="active"},
                new BlindSpotQuizAttempts{id = 4,selectedcoWorkers = new []{"Anuth","Hashim","Arjit"},selectedadjectives = new string[]{"able","accepting","adaptable","bold","brave","calm"},userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),status="active"},
                 new BlindSpotQuizAttempts{id = 5,selectedcoWorkers = new []{"Anuth","Hashim","Arjit"},selectedadjectives = new string[]{"able","accepting","adaptable","bold","brave","calm"},userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),status="active"},
                 new BlindSpotQuizAttempts{id = 6,selectedcoWorkers = new []{"Hamid","Anuth","Arjit"},selectedadjectives = new string[]{"able","accepting","adaptable","bold","brave","calm"},userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),status="active"},

            };
        }

        public static List<ContinuousLearningAssessmentQuizAttempts> ContinuousLearningResponses()
        {
            return new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts(){id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 4,questionid = 4,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 5,questionid = 5,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 6,questionid = 6,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 7,questionid = 7,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 8,questionid = 8,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 9,questionid = 9,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 10,questionid = 10,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 11,questionid = 11,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 12,questionid = 12,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 13,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 14,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 15,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 16,questionid = 4,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 17,questionid = 5,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 18,questionid = 6,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=false,somewhat=true},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                 new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=false,no=true,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
                new ContinuousLearningAssessmentQuizAttempts{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),yes=true,no=false,somewhat=false},
            };
        }

        public static List<LearningMythsQuizAttempts> LearningMythsResponses()
        {
            return new List<LearningMythsQuizAttempts>
            {
               new LearningMythsQuizAttempts{id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 4,questionid = 4,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 5,questionid = 5,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 6,questionid = 6,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 7,questionid = 7,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 8,questionid = 8,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 9,questionid = 9,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 10,questionid = 10,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 11,questionid = 11,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 12,questionid = 12,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 13,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 14,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 15,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 16,questionid = 4,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 17,questionid = 5,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 18,questionid = 6,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                 new LearningMythsQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
                new LearningMythsQuizAttempts{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),selectedoption="Read and then reread"},
            };
        }

        public static List<ProductivityZoneQuizAttempts> ProductivityZoneResponses()
        {
            return new List<ProductivityZoneQuizAttempts>
            {
                new ProductivityZoneQuizAttempts(){id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 4,questionid = 4,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 5,questionid = 5,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 6,questionid = 6,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 7,questionid = 7,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 8,questionid = 8,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 9,questionid = 9,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 10,questionid = 10,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 11,questionid = 11,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 12,questionid = 12,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 13,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 14,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 15,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 16,questionid = 4,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 17,questionid = 5,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 18,questionid = 6,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                 new ProductivityZoneQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new ProductivityZoneQuizAttempts{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},

            };
        }

        public static List<ReflectionTool> ReflectionQuestions()
        {

            return new List<ReflectionTool>
            {
                new ReflectionTool{id = 1,type ="text",question = "What are the top three things you learned? (Seperate by comma)"},
                new ReflectionTool{id = 2,type = "select",question = "Why did you choose to take this training?  Select top 3 from the options below",options= new [] {"For inspiraion","To innovate","For the joy of learning","To discover new things","To keep up to date with what is happening in IT"}},
                new ReflectionTool{id=3,type = "mc3",question = "I would like to learn more about these topics"}
            };
        }


        public static List<ReflectionToolQuizAttempt> ReflectionToolQuizResponses()
        {
            return new List<ReflectionToolQuizAttempt>
           {
               new ReflectionToolQuizAttempt{id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 4,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 5,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 6,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 7,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 8,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 9,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 10,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 11,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 12,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 13,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 14,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 15,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 16,questionid = 1,userid = "Hashim",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 17,questionid = 2,userid = "Hashim",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 18,questionid = 3,userid = "Hashim",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                 new ReflectionToolQuizAttempt{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                new ReflectionToolQuizAttempt{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always",selectedoptions = new List<string>{"option1","option2"},updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)},

           };
        }

        public static List<StoryTellingForImpactQuizAttempts> StoryTellingForImpactResponses()
        {
            return new List<StoryTellingForImpactQuizAttempts>
            {
                new StoryTellingForImpactQuizAttempts(){id = 1,questionid = 1,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 2,questionid = 2,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 3,questionid = 3,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 4,questionid = 4,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 5,questionid = 5,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 6,questionid = 6,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 7,questionid = 7,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 8,questionid = 8,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 9,questionid = 9,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 10,questionid = 10,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 11,questionid = 11,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 12,questionid = 12,userid = "Hamid",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 13,questionid = 1,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 14,questionid = 2,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 15,questionid = 3,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 16,questionid = 4,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 17,questionid = 5,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 18,questionid = 6,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 19,questionid = 7,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 20,questionid = 8,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 21,questionid = 9,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 22,questionid = 10,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 23,questionid = 11,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 24,questionid = 12,userid = "Hamid",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 25,questionid = 1,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 26,questionid = 2,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 27,questionid = 3,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 28,questionid = 4,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 29,questionid = 5,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 6,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 7,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 8,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 9,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 10,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 11,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 12,userid = "Hamid",attemptcount=3,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                 new StoryTellingForImpactQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 1,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 2,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 3,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 4,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 5,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 6,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 7,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 8,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 9,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 10,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 11,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 12,userid = "Hashim",attemptcount=2,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 1,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 2,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 3,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 4,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 5,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 6,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 7,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 8,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 9,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 10,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 11,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},
                new StoryTellingForImpactQuizAttempts{id = 1,questionid = 12,userid = "Anuth",attemptcount=1,attempttimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),answer="always"},

            };
        }

        public static BlindSpotQuizQuestions BlindSpotQuestions()
        {
            return new BlindSpotQuizQuestions
            {
                id = 1,
                adjectives = new String[] {"able", "accepting", "adaptable", "bold", "brave", "calm", "caring", "cheerful", "clever", "complex"
                , "confident", "dependable", "dignified", "energetic", "extroverted", "friendly", "kind"},
                selectedcwmaxcount = 4,
                selectedadmaxcount = 6
            };
        }

        public static List<BlindSpotCoWorkerReply> BlindSpotCoWorkerReplies()
        {
            return new List<BlindSpotCoWorkerReply>
            {
                new BlindSpotCoWorkerReply()
                {
                    id = 1,
                    selectedadjectives = new String[]
                    {
                         "caring", "cheerful", "clever",
                        "complex", "confident", "dependable"
                    },
                    attemptid = 1,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hamid"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 2,
                    selectedadjectives = new String[]
                    {
                        "dependable", "dignified", "energetic", "extroverted", "friendly",
                        "kind"
                    },
                    attemptid = 1,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hashim"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 3,
                    selectedadjectives = new String[]
                    {
                        "caring", "cheerful", "clever",
                        "complex", "confident", "dependable",
                    },
                    attemptid = 1,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Arjit"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 4,
                    selectedadjectives = new String[]
                    {
                        "caring", "cheerful", "clever",
                        "complex", "confident", "dependable"
                    },
                    attemptid = 2,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hamid"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 5,
                    selectedadjectives = new String[]
                    {
                        "dependable", "dignified", "energetic", "extroverted", "friendly",
                        "kind"
                    },
                    attemptid = 2,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hashim"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 6,
                    selectedadjectives = new String[]
                    {
                        "caring", "cheerful", "clever",
                        "complex", "confident", "dependable",
                    },
                    attemptid = 2,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Arjit"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 7,
                    selectedadjectives = new String[]
                    {
                        "caring", "cheerful", "clever",
                        "complex", "confident", "dependable"
                    },
                    attemptid = 3,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hamid"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 8,
                    selectedadjectives = new String[]
                    {
                        "dependable", "dignified", "energetic", "extroverted", "friendly",
                        "kind"
                    },
                    attemptid = 3,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hashim"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 9,
                    selectedadjectives = new String[]
                    {
                        "caring", "cheerful", "clever",
                        "complex", "confident", "dependable",
                    },
                    attemptid = 3,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Arjit"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 10,
                    selectedadjectives = new String[]
                    {
                         "brave", "calm", "caring", "cheerful", "clever",
                        "complex", "confident"
                    },
                    attemptid = 4,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Anuth"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 11,
                    selectedadjectives = new String[]
                    {
                         "bold", "brave", "calm", "caring", "cheerful", "clever",
                        "complex", "kind"
                    },
                    attemptid = 4,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hashim"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 12,
                    selectedadjectives = new String[]
                    {
                        "bold", "brave", "calm",
                        "complex", "confident", "dependable"
                    },
                    attemptid = 4,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Arjit"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 13,
                    selectedadjectives = new String[]
                    {
                        "brave", "calm", "caring", "cheerful", "clever",
                        "complex", "confident"
                    },
                    attemptid = 5,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Anuth"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 14,
                    selectedadjectives = new String[]
                    {
                        "bold", "brave", "calm", "caring", "cheerful", "clever",
                        "complex", "kind"
                    },
                    attemptid = 5,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hashim"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 15,
                    selectedadjectives = new String[]
                    {
                        "bold", "brave", "calm",
                        "complex", "confident", "dependable"
                    },
                    attemptid = 5,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Arjit"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 16,
                    selectedadjectives = new String[]
                    {
                        "able", "accepting", "energetic", "extroverted", "friendly",
                        "kind"
                    },
                    attemptid = 6,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Anuth"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 17,
                    selectedadjectives = new String[]
                    {
                        "able", "accepting", "dignified", "energetic", "extroverted", "friendly"
                    },
                    attemptid = 6,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Hamid"

                },
                new BlindSpotCoWorkerReply()
                {
                    id = 18,
                    selectedadjectives = new String[]
                    {
                        "able", "accepting", "dependable", "dignified", "energetic", "extroverted"
                    },
                    attemptid = 6,
                    replytimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    userid = "Arjit"

                }

            };
        }
    }
}
