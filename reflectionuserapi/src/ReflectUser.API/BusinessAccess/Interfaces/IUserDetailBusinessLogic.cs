using ReflectUser.API.Models;
using System.Collections.Generic;

namespace ReflectUser.API.BusinessAccess.Interfaces
{
    public interface IUserDetailBusinessLogic
    {
        List<UserDetails> GetUserDetails(string userId = "");

        List<UserDetails> GetUsersByRole(string role);

        void FillUserData();

        UserDetails GetUserDetails(string userId, string emailId);
    }
}
