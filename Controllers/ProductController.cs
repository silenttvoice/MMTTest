using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTTestApi.Interfaces;
using MMTTestApi.Models;

namespace MMTTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts", Name = "GetAllProducts")]
        [ProducesResponseType(typeof(ICollection<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetProductsByCategoryId/{categoryId}", Name = "GetProductsByCategoryId")]
        [ProducesResponseType(typeof(ICollection<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsByCategoryId(Guid categoryId)
        {
            try
            {
                return Ok(await _productService.GetProductsByCategoryId(categoryId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}