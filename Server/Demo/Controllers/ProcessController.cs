using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        IProcessService processService;
        IProcessCategoryService categoryService;
        IPhaseService phaseService;

        public ProcessController(IProcessService processService, IProcessCategoryService categoryService, IPhaseService phaseService)
        {
            this.processService = processService;
            this.categoryService = categoryService;
            this.phaseService = phaseService;
        }

        /// <summary>
        /// Api cho việc lấy tất cả các bản ghi process
        /// </summary>
        [HttpGet()]
        public IActionResult getAll()
        {
            string [] includes = new string[1] { "Category"};
            var result = processService.GetAll(includes);
          
            var r = result.First();

            var rr = r.GetType().GetProperty("Description").Name;
          
            return Ok(result);


        }

        /// <summary>
        /// Api cho việc lấy một process theo processId
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            string[] includes = new string[2] { "Phase", "Category" };
            var result = processService.GetSingleByCondition(x => x.ProcessId == id, includes);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Process khong ton tai");

        }


        /// <summary>
        /// //Api cho việc tìm kiếm, sắp xếp và phân trang
        /// </summary>
        [HttpPost("page")]
        public IActionResult getMultiPaging(Paging paging)
        {
            string[] includes = new string[1] { "Category" };
            var result = processService.GetMultiPaging(paging, out int total,includes);

            Result<Process> dataResponse = new Result<Process>()
            {
                Data = result,
                TotalRow = total,
            };

            return Ok(dataResponse);

        }

        /// <summary>
        ///  Api cho việc tạo mới process
        /// </summary>
        [HttpPost()]
        public IActionResult AddProcess(Process process)
        {

            ProcessCategory category = null;

            if (categoryService.Add(process.Category) != null)   // them mới thành công
            {
                categoryService.Save();   // Lưu lại trong database
            }


            category = categoryService.GetSingleByCondition(x => x.Name.ToUpper() == process.Category.Name.ToUpper());

            process.CategoryId = category.CategoryId;

            processService.Add(process);
            processService.Save();

            phaseService.AddWhenCreateProcess(process.ProcessId);
            phaseService.Save();

            return Ok(process.ProcessId);
        }

        [HttpPut()]
        public IActionResult UpdateProcess(Process process)
        {

            ProcessCategory category = null;

            if (categoryService.Add(process.Category) != null)   // them mới thành công
            {
                categoryService.Save();   // Lưu lại trong database
            }


            category = categoryService.GetSingleByCondition(x => x.Name.ToUpper() == process.Category.Name.ToUpper());

            process.CategoryId = category.CategoryId;

            processService.Update(process);
            processService.Save();

            return Ok(process.ProcessId);
        }
    }
}