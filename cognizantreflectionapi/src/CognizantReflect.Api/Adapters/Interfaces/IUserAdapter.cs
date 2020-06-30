using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CognizantReflect.Api.Models.UserService;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IUserAdapter
    {
        List<UserDetails> GetUserList();
    }
}
