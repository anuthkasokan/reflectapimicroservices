using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReflectUser.API.Adapters.Interfaces;
using ReflectUser.API.Helpers.Interfaces;
using ReflectUser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ReflectUser.API.Handlers;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ReflectUser.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ReflectUser.API.Adapters
{
    internal class UserDetailDataAdapter : IAdapter
    {
        private readonly IMongoClientHelper<UserDetails> _userDetails;

        private readonly string _userDetailsCollection;

        public UserDetailDataAdapter(IMongoClientHelper<UserDetails> userDetails, IOptions<MongoDbSettings> settings)
        {
            _userDetails = userDetails ?? throw new ArgumentNullException();
            _userDetailsCollection = settings.Value.UsersCollection;
        }

        public List<UserDetails> GetUserDetailsById(string userId)
        {
            var result = _userDetails.GetUserDataById(FilterDefinitionHandler.FilterUserDetailsByUserId(userId), _userDetailsCollection);

            if (result == null || result.Count == 0)
                result = _userDetails.GetUserDataById(FilterDefinitionHandler.FilterUserDetailsByEmailId(userId),
                _userDetailsCollection);

            if (result != null && result.Any())
            {
                return result;
            }


            return new List<UserDetails>();
        }

        public List<UserDetails> GetUserDetailsByRole(string role)
        {

            var result = _userDetails.GetUserDataById(FilterDefinitionHandler.FilterUserDetailsByRole(role), _userDetailsCollection);

            if (result != null && result.Any())
            {
                return result;
            }


            return new List<UserDetails>();
        }

        public List<UserDetails> GetAllUserDetails()
        {

            var result = _userDetails.GetUserData(_userDetailsCollection);

            if (result != null && result.Any())
            {
                return result;
            }


            return new List<UserDetails>();
        }

        public void FillUserData()
        {
            _userDetails.InsertMany(GetSampleUsers(), _userDetailsCollection);
        }

        private List<UserDetails> GetSampleUsers()
        {
            return new List<UserDetails> {
                new UserDetails { id=1,userid="Hamid",emailid = GetEmailId("hamidnk77"),role="User",updatetimestamp = DateTime.Now.ToString() } ,
                new UserDetails { id=2,userid="Anuth",emailid = GetEmailId("anuthkasokan"),role="User",updatetimestamp = DateTime.Now.ToString() },
                new UserDetails { id=3,userid="Hashim",emailid = GetEmailId("hashim01"),role="Admin",updatetimestamp = DateTime.Now.ToString() },
                new UserDetails { id=4,userid="Prashanth",emailid = "prashant.parekh@cognizant.com",role="Admin",updatetimestamp = DateTime.Now.ToString() },
                new UserDetails { id=5,userid="Future",emailid = "codejammershha@outlook.com",role="Admin",updatetimestamp = DateTime.Now.ToString() },
                new UserDetails { id=6,userid="Vyshnav",emailid = GetEmailId("Vyshnav"),role="User",updatetimestamp = DateTime.Now.ToString() },
                new UserDetails { id=7,userid="Faizal",emailid = GetEmailId("Faizal"),role="User",updatetimestamp = DateTime.Now.ToString() }
            };
        }



        private string GetEmailId(string emailPrefix)
        {
            var email = emailPrefix + "@gmail.com";
            return email;
        }

        public void InsertUserDetail(UserDetails user)
        {
            _userDetails.InsertOne(user, _userDetailsCollection);
        }

        public long LastInsertedId()
        {
            return _userDetails.GetUserData(_userDetailsCollection)?
                .OrderByDescending(x => x.id)?.FirstOrDefault()?.id ?? 0;
        }

    }
}
