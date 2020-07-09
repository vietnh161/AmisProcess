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
        IUserService userService;
        IProcessCategoryService categoryService;
        IPhaseService phaseService;

        public ProcessController(IProcessService processService, IUserService userService, IProcessCategoryService categoryService, IPhaseService phaseService)
        {
            this.processService = processService;
            this.userService = userService;
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
          
           
          
            return Ok(result);


        }

        /// <summary>
        /// Api cho việc lấy một process theo processId
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult getById(Guid id)
        {
            string[] includes = new string[2] { "Phase", "Category" };
            var result = processService.GetSingleByCondition(x => x.ProcessId.Equals(id), includes);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Process khong ton tai");

        }

        [HttpGet("test/{id}")]
        public IActionResult getByIda(Guid id)
        {
            string[] includes = new string[2] { "Phase", "Category" };
            var result = processService.GetSingleByCondition(x => x.ProcessId.Equals(id), includes);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Process khong ton tai");

        }

        /// <summary>
        /// Api cho việc lấy một process theo processId bao gồm cả field 
        /// </summary>
        [HttpGet("includeField/{id}")]
        public IActionResult getByIdIncludeField(Guid id)
        {
            string[] includes = new string[5] { "Phase", "Phase.Field", "Phase.Field.FieldOption", "Phase.PhaseEmployee", "Phase.PhaseEmployee.Employee" };
            var result = processService.GetSingleByCondition(x => x.ProcessId == id, includes);
            if (result != null)
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
            User currentUser = userService.GetCurrentUser(User.Identity.Name);

            Category category = null;

            if (categoryService.Add(process.Category) != null)   // them mới thành công
            {
                categoryService.Save();   // Lưu lại trong database
            }


            category = categoryService.GetSingleByCondition(x => x.Name.ToUpper() == process.Category.Name.ToUpper());

            process.CategoryId = category.CategoryId;

            processService.Add(process, currentUser);
            processService.Save();

            phaseService.AddWhenCreateProcess(process.ProcessId);
            phaseService.Save();

            return Ok(process.ProcessId);
        }

        [HttpPut()]
        public IActionResult UpdateProcess(Process process)
        {
            User currentUser = userService.GetCurrentUser(User.Identity.Name);

            Category category = null;

            if (categoryService.Add(process.Category) != null)   // them mới thành công
            {
                categoryService.Save();   // Lưu lại trong database
            }


            category = categoryService.GetSingleByCondition(x => x.Name.ToUpper() == process.Category.Name.ToUpper());

            process.CategoryId = category.CategoryId;

            processService.Update(process, currentUser);
            processService.Save();

            return Ok(process.ProcessId);
        }
    }
}