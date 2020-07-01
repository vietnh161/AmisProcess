using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IProcessCategoryService processCategoryService;

        public CategoryController(IProcessCategoryService processCategoryService)
        {
            this.processCategoryService = processCategoryService;
        }

        [HttpGet()]
        public IActionResult getAll()
        {
           
            var result = processCategoryService.GetAll();
            return Ok(result);

        }

        [HttpGet()]
        [Route("{id}")]
        public IActionResult getById(Guid id)
        {

            var result = processCategoryService.GetById(id);
            return Ok(result);

        }
    }
}