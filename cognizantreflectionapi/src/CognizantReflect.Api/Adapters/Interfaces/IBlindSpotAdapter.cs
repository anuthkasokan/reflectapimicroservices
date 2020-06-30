using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CognizantReflect.Api.Models.BlindSpotQuiz;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IBlindSpotAdapter
    {
        BlindSpotQuizQuestions GetBlindSpotQuizQuestions();

        void SaveBlindSpotUserResponse(BlindSpotQuizAttempts response);

        void SaveBlindSpotCoWorkerResponse(BlindSpotCoWorkerReply response);

        void UpdateBlindSpotCoWorkerResponse(BlindSpotCoWorkerReply response);

        BlindSpotQuizAttempts GetLatestAttemptByUser(string user);
        BlindSpotQuizAttempts GetBlindSpotAttemptResponse(int attemptid, string userid);

        List<BlindSpotCoWorkerReply> GetCoWorkerResponsesByAttempt(long attemptId);

        long GetLastInsertedAttemptId();

        long GetLastInsertedCoWorkerReply();

        List<BlindSpotCoWorkerReply> GetDataForCoWorkerReply(int attemptid);
        List<BlindSpotCoWorkerReply> GetDataForCoWorkerReply(string userid);
    }
}
