using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Helpers
{
    internal static class SampleData
    {
        public static List<Feedback> FeedbackList()
        {
            return new List<Feedback>
            {
                new Feedback {id= 1,userid="Hamid", question = "You would prefer complex to simple problems.",assigned="Hashim",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback {id= 2,userid="Anuth", question= "I like to have the responsibility of handling a situation that requires a lot of thinking.",assigned="Hamid", createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback {id= 3,userid="Hashim", question= "I usually end up deliberating about issues even when they do not affect me personally.",assigned="Hamid",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback {id= 4,userid="Hamid", question= "I would prefer complex to simple problems.",assigned="",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback  {id= 5,userid="Hashim", question= "I like to have the responsibility of handling a situation that requires a lot of thinking.",assigned="Hamid",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback  {id= 6,userid="Hamid", question= "You have been requested for blind spot by your friend Hamid",assigned="Hashim",createtimestamp = DateTime.Now.ToString(),type = "blindspot",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback {id= 7,userid="Anuth", question= "I would prefer complex to simple problems.",assigned="Hashim",createtimestamp = DateTime.Now.ToString(),type = "blindspot",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback  {id= 8,userid="Hashim", question= "I like to have the responsibility of handling a situation that requires a lot of thinking.",assigned="Hamid",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "closed"},
                new Feedback {id= 9,userid="Hamid",question= "I usually end up deliberating about issues even when they do not affect me personally.",assigned="Anuth",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback  {id= 10,userid="Anuth", question= "I would prefer complex to simple problems.",assigned="",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback  {id= 11,userid="Hashim",question= "You have been requested for blind spot by your friend Hashim.",assigned="Hamid",createtimestamp = DateTime.Now.ToString(),type = "blindspot",updatetimestamp = DateTime.Now.ToString(),status = "pending"},
                new Feedback {id= 12,userid="Hamid", question= "I usually end up deliberating about issues even when they do not affect me personally.",assigned="Hashim",createtimestamp = DateTime.Now.ToString(),type = "feedback",updatetimestamp = DateTime.Now.ToString(),status = "pending"},

            };
        }

        public static List<FeedbackReply> FeedbackReplies()
        {
            return new List<FeedbackReply>
            {
                new FeedbackReply {id= 1,userid="Hashim", feedbackid = 1, feedback = "I would prefer complex to simple problems.",createtimestamp = DateTime.Now.ToString()},
                new FeedbackReply {id= 2,userid="Hamid", feedbackid = 2, feedback = "I like to have the responsibility of handling a situation that requires a lot of thinking.", createtimestamp = DateTime.Now.ToString()},
                new FeedbackReply {id= 3,userid="Hamid", feedbackid = 3, feedback = "I usually end up deliberating about issues even when they do not affect me personally.",createtimestamp = DateTime.Now.ToString()},
                new FeedbackReply  {id= 4,userid="Hamid", feedbackid = 5, feedback = "I like to have the responsibility of handling a situation that requires a lot of thinking.",createtimestamp = DateTime.Now.ToString()},
                new FeedbackReply  {id= 5,userid="Hashim", feedbackid = 7, feedback = "You have been requested for blind spot by your friend Hamid",createtimestamp = DateTime.Now.ToString()},
                new FeedbackReply {id= 6,userid="Hamid", feedbackid = 8, feedback = "I would prefer complex to simple problems.",createtimestamp = DateTime.Now.ToString()},
                new FeedbackReply  {id= 7,userid="Anuth", feedbackid = 9, feedback = "I like to have the responsibility of handling a situation that requires a lot of thinking.",createtimestamp = DateTime.Now.ToString()},
                new FeedbackReply {id= 8,userid="Hashim",feedbackid = 12, feedback = "I usually end up deliberating about issues even when they do not affect me personally.",createtimestamp = DateTime.Now.ToString()}
            };
        }
    }
}
