using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("getmulti/{keyword}")]
        public IActionResult GetMultiPaging(string keyword)
        {
            var result = employeeService.GetMulti(keyword);
            return Ok(result);


        }

        [HttpPost("getEmployeeImplement")]
        public IActionResult GetMultiByEmployeeCode([FromBody]string employeeCode)
        {
            //var result = employeeService.GetMulti(keyword);
            //return Ok(result);


            return Ok();

        }

        [HttpPost("checkEmployeeExist")]
        public IActionResult CheckEmployeeExist(Employee employee)
        {
            var result = employeeService.CheckEmployeeExist(employee.EmployeeCode, employee.FullName);


            return Ok(result);
        }

        [HttpPost("getSingleByCondition")]
        public IActionResult GetSingleByCondition(Employee employee)
        {
            var eCode = employee.EmployeeCode;
            var eFullName = employee.FullName;

            var result = employeeService.GetSingleByCondition(x => x.EmployeeCode.ToUpper().Contains(eCode.ToUpper()) && x.FullName.ToUpper().Contains(eFullName.ToUpper()));

            return Ok(result);
        }
    }
}