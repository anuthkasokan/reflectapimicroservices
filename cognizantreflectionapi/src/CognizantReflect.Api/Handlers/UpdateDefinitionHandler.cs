using CognizantReflect.Api.Models.BlindSpotQuiz;
using MongoDB.Driver;

namespace CognizantReflect.Api.Handlers
{
    internal static class UpdateDefinitionHandler
    {
        internal static UpdateDefinition<BlindSpotCoWorkerReply> UpdateCoWorkerResponse(string[] selectedAdjectives)
            => Builders<BlindSpotCoWorkerReply>.Update.Set(f => f.selectedadjectives, selectedAdjectives);
    }
}
