using System.Runtime.CompilerServices;
using CognizantReflect.Api.Models.FeedbackService;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IFeedbackAdapter
    {
        void SendNotification(BlindSpotNotification notification);
    }
}
