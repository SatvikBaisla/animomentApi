using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Data;
using animomentapi.Dto.Category;
using animomentapi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace animomentapi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesRepository _categoryRepo;
        public ProductCategoriesController(IProductCategoriesRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        //Get all categories
        [HttpGet("get_all_categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryRepo.GetAllProductAsync();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        //get a category by id
        [HttpGet("get_category_by_id/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var result = await _categoryRepo.GetCategoryByIdAsync(id);
            if (result == null) return NotFound();
            else return Ok(result);
        }

        //edit a product by id
        [HttpPut("edit_category_by_id/{id}")]
        public async Task<IActionResult> EditCategory([FromRoute] int id, [FromBody] UpdateCategoryDto dto)
        {
            var result = await _categoryRepo.EditCategoryAsync(id, dto);

            if (result == null) return NotFound();
            else return Ok(result);
        }
    }
}