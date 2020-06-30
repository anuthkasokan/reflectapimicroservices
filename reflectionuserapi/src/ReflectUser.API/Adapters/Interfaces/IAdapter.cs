using ReflectUser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectUser.API.Adapters.Interfaces
{
    internal interface IAdapter
    {
        List<UserDetails> GetAllUserDetails();

        List<UserDetails> GetUserDetailsByRole(string role);

        List<UserDetails> GetUserDetailsById(string userId);

        void FillUserData();

        void InsertUserDetail(UserDetails user);

        long LastInsertedId();
    }
}