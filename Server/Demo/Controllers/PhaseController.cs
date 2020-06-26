using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhaseController : ControllerBase
    {
        IPhaseService phaseService;
        public PhaseController(IPhaseService phaseService)
        {
            this.phaseService = phaseService;
        }

        /// <summary>
        ///  API lay process theo id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = phaseService.GetById(id);
            if(result == null) return BadRequest("phase khong ton tai");
            return Ok(result);
        }


        [HttpGet("getbyprocess/{processId}")]
        public IActionResult GetByProcessId(int processId)
        {
            string[] includes = new string[2] { "Field", "Field.Option" };
            var result = phaseService.GetMulti(x => x.ProcessId == processId,includes);
           
            if (!result.Any()) return BadRequest("process khong ton tai");
            return Ok(result);
        }
    }
}