using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessAccess;
using DataAccess.Models;
using DataAccess;
using MySql.Data.MySqlClient;

namespace Demo.Controllers
{
   
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User userInfo)
        {

            var user = _userService.GetSingleByCondition(x => x.Username == userInfo.Username && x.Password == userInfo.Password);

            if (user == null)
                return BadRequest(new { message = "Tai khoan hoac mat khau khong dung" });



            var token = _userService.GetToken(user.Username, user.Role.RoleName);

            var result = new AuthenModel()
            {
                FullName = user.Employee.First().FullName,
                UserName = user.Username,
                Role = user.Role.RoleName,
                Token = token
            };

            return Ok(result);
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            var b = _userService.GetCurrentUser(User.Identity.Name);
           
            return Ok();
        }
        [HttpGet("getUserLogged")]
        [Authorize]
        public IActionResult GetUserLogged()
        {
            var user  = _userService.GetCurrentUser(User.Identity.Name);

            var token = _userService.GetToken(user.Username, user.Role.RoleName);
            var result = new AuthenModel()
            {
                FullName = user.Employee.First().FullName,
                UserName = user.Username,
                Role = user.Role.RoleName,
                Token = token,
            };
            return Ok(result);
        }
    }
}