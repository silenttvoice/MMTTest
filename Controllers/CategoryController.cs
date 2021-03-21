using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTTestApi.Interfaces;
using MMTTestApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories", Name = "GetAllCategories")]
        [ProducesResponseType(typeof(ICollection<Category>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                return Ok(await _categoryService.GetAllCategories());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}