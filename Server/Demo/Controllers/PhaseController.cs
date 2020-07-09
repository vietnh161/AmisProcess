using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhaseController : ControllerBase
    {
        IFieldService fieldService;
        IPhaseService phaseService;
        IPhaseEmployeeService phaseEmployeeService;
        IProcessService processService;
        public PhaseController(IFieldService fieldService, IPhaseEmployeeService phaseEmployeeService, IPhaseService phaseService, IProcessService processService)
        {
            this.fieldService = fieldService;
            this.phaseService = phaseService;
            this.processService = processService;
            this.phaseEmployeeService = phaseEmployeeService;
        }

        /// <summary>
        ///  API lay process theo id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = phaseService.GetById(id);
            if(result == null) return BadRequest("phase khong ton tai");
            return Ok(result);
        }


        [HttpGet("getbyprocess/{processId}")]
        public IActionResult GetByProcessId(Guid processId)
        {
            string[] includes = new string[4] { "Field", "Field.FieldOption", "PhaseEmployee" , "PhaseEmployee.Employee" };
            var result = phaseService.GetMulti(x => x.ProcessId == processId,includes);
           
            if (!result.Any()) return BadRequest("process khong ton tai");
            return Ok(result);
        }

        [HttpPut()]
        public IActionResult UpdateMultiPhase(ModifiedPhase modifiedPhase)
        {
            foreach (var i in modifiedPhase.ListPhaseDelete)     // Xóa những phase có trong danh sách id xóa
            {

                var isPhaseExist = phaseService.CheckExist(x => x.PhaseId == i);
                if (isPhaseExist == true)
                {
                    phaseService.Delete(i);
                }
            }

            foreach (var i in modifiedPhase.ListFieldDelete)     // Xóa những field có trong danh sách id xóa
            {

                var isFieldExist = fieldService.CheckExist(x => x.FieldId == i);
                if (isFieldExist == true)
                {
                    fieldService.Delete(i);
                }

            }

            foreach (var i in modifiedPhase.ListEmployeeDelete)     // Xóa những employee có trong danh sách id xóa
            {

                var isFieldExist = phaseEmployeeService.CheckExist(x => x.PhaseEmployeeId == i);
                if (isFieldExist == true)
                {
                   phaseEmployeeService.Delete(i);
                }
            }

            foreach (var phase in modifiedPhase.Phase)
            {
                if (phase.PhaseId == null || phase.PhaseId.Equals(""))
                {
                    phase.PhaseId = Guid.NewGuid();
                }

                phaseService.AddOrUpdate(phase);
            }
            var processUpdated = processService.GetById(modifiedPhase.ProcessId);
            processUpdated.UpdatedAt = DateTime.Now;
            processUpdated.UpdatedBy = "e - 12345";


            phaseService.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = phaseService.Delete(id);
            if (result == null) return BadRequest("phase khong ton tai");
            phaseService.Save();
            return Ok(result.ProcessId);
        }
    }

}