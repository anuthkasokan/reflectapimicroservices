using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CognizantReflect.Api.Helpers.Interfaces
{
    internal interface IProgramDependencyHelper
    {
        void ScopedDependencies(IConfiguration configuration, IServiceCollection services);
    }

}
