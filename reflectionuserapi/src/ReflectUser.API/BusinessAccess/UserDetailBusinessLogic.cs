using ReflectUser.API.Adapters.Interfaces;
using ReflectUser.API.BusinessAccess.Interfaces;
using ReflectUser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReflectUser.API.BusinessAccess
{
    internal class UserDetailBusinessLogic : IUserDetailBusinessLogic
    {
        private IAdapter _userDetailAdapter;

        public UserDetailBusinessLogic(IAdapter userDetailDataAdapter)
        {
            _userDetailAdapter = userDetailDataAdapter ?? throw new ArgumentNullException();
        }
        public List<UserDetails> GetUserDetails(string userId = "")
        {
            if (string.IsNullOrEmpty(userId))
                return _userDetailAdapter.GetAllUserDetails();

            else
                return _userDetailAdapter.GetUserDetailsById(userId);

        }

        public UserDetails GetUserDetails(string userId,string emailId)
        {

            var userDetails= _userDetailAdapter.GetUserDetailsById(emailId);

            if (userDetails == null || !userDetails.Any())
            {
                UserDetails detail = new UserDetails
                {
                    emailid = emailId,
                    userid = userId.Split(" ")[0],
                    id = _userDetailAdapter.LastInsertedId()+1,
                    role = "User",
                    updatetimestamp = DateTime.Now.ToString()
                };

                _userDetailAdapter.InsertUserDetail(detail);
                return detail;
            }

            return userDetails.FirstOrDefault();

        }

        public List<UserDetails> GetUsersByRole(string role)
        {
            return _userDetailAdapter.GetUserDetailsByRole(role);
        }

        public void FillUserData()
        {
            _userDetailAdapter.FillUserData();
        }
    }
}
