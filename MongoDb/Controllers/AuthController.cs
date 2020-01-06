using MongoDb.Data.Models;
using MongoDb.Models.Request;
using MongoDb.Service.Implementations;
using MongoDb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MongoDb.Controllers
{
    [Route("user")]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;
        private readonly IMongoDbRepository<User> _userRepository;
        public AuthController()
        {
            _authService = new AuthService();
            _userRepository = new Repository<User>();
        }


        [HttpPost]
        public IHttpActionResult Register([FromBody] User user)
        {
            _userRepository.Add("user", user);
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserLoginModel user)
        {
            var a=_authService.Login(user.UserName, user.Password);
            return Ok();
        }
    }
}
