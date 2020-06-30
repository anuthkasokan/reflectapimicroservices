using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CognizantReflect.Api.Models.BlindSpotQuiz;


namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IBlindSpotBusinessLogics
    {
        BlindSpotQuizQuestions GetBlindSpotQuizQuestions();

        void SaveBlindSpotUserResponse(BlindSpotQuizAttempts response);

        void SaveBlindSpotCoWorkerReply(BlindSpotCoWorkerReply response);

        void UpdateBlindSpotCoWorkerReply(BlindSpotCoWorkerReply response);

        BlindSpotQuizResult ShowBlindSpotQuizResult(string user);

        List<BlindSpotCoWorkerReply> GetBlindSpotCoWorkerRequest(string userid);
    }
}
