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
            //private IUserService _userService;

            //public AccountController(IUserService userService)
            //{
            //    _userService = userService;
            //}

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
            List<User> users = new List<User>();
            var connectionString = "server=192.168.15.18;port=3306;user=dev;password=12345678@Abc;database=MISA.AmisProcess";
            var mySqlConnection = new MySqlConnection(connectionString);
            var command = mySqlConnection.CreateCommand();


            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "getAllUser";
  
            mySqlConnection.Open();
            var sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var history = new User();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    var columnName = sqlDataReader.GetName(i);
                    var cellValue = sqlDataReader.GetValue(i);
                    var property = history.GetType().GetProperty(columnName);
                    if (property != null)
                        property.SetValue(history, cellValue);
                }
                users.Add(history);
            }
            mySqlConnection.Close();
            return Ok(users);

             }

        ////[HttpGet("get/{id}")]
        ////public IActionResult Get(Guid id)
        ////{
        ////    AmisProcessDbContext m = new AmisProcessDbContext();
        ////    var a = m.Set<User>().AsQueryable();
        ////    return Ok(a);

        ////}

    }
}