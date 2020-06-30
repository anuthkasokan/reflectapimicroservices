using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReflectUser.API.BusinessAccess.Interfaces;
using ReflectUser.API.Models;

namespace ReflectUser.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly ILogger<UserDetailsController> _logger;
        private readonly IUserDetailBusinessLogic _userDetailBusinessLogic;

        public UserDetailsController(ILogger<UserDetailsController> logger, IUserDetailBusinessLogic userDetailBusinessLogic)
        {
            _logger = logger;
            _userDetailBusinessLogic = userDetailBusinessLogic;
        }

        [HttpGet("getUser/{userid}", Name = "GetUserByUserId/EmailId")]
        public List<UserDetails> GetUserById(string userId)
        {
            return _userDetailBusinessLogic.GetUserDetails(userId);
        }

        [HttpGet("getUser/{userid}/{emailid}", Name = "GetloggedUser/UserId/EmailId")]
        public UserDetails GetLoggedUser(string userId,string emailId)
        {
            return _userDetailBusinessLogic.GetUserDetails(userId,emailId);
        }

        [HttpGet("getUser", Name = "GetAllUsers")]
        public List<UserDetails> GetUserById()
        {
            return _userDetailBusinessLogic.GetUserDetails();

        }

        [HttpGet("getUsersByRole/{role}", Name = "GetUsersByRole")]
        public List<UserDetails> GetUsersByRole(string role)
        {
            return _userDetailBusinessLogic.GetUsersByRole(role);
        }

    }
}
