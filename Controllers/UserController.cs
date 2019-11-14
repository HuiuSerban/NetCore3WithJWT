using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CoreJWT.ActionFIlters;
using CoreJWT.Models;
using CoreJWT.Models.DTOs;
using CoreJWT.Repositories;
using CoreJWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreJWT.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;

        public UserController()
        {
            _repo = new UserRepository();
        }

        [HttpGet]
        [CustomActionFilter]
        public IEnumerable<User> GetAllUser()
        {
            var users = _repo.GetUsers();
            return users;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _repo.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}