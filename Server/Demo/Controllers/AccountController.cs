using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessAccess;
using DataAccess.Models;

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

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate(User userInfo)
        //{

        //    var user = _userService.GetSingleByCondition(x => x.Username == userInfo.Username && x.Password == userInfo.Password);

        //    if (user == null)
        //        return BadRequest(new { message = "Tai khoan hoac mat khau khong dung" });

        //    var token = _userService.GetToken(user.Username, user.Role.Name);

        //    var result = new AuthenModel()
        //    {
        //        FirstName = user.Employee.FirstName,
        //        LastName = user.LastName,
        //        Role = user.Role.Name,
        //        Token = token
        //    };

        //    return Ok(result);
        //}

        [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
        
    }
}