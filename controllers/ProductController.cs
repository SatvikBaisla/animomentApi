using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Interface;
using Microsoft.AspNetCore.Mvc;
using animomentapi.Mapper;
using animomentapi.Dto.Product;

namespace animomentapi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet("get_all_products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepo.GetAllProductAsync();

            if (products == null) NotFound();

            var result = products.Select(s => s.ToProductDto());
            return Ok(result);
        }

        [HttpPost("add_product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto dto)
        {
            var product = dto.FromDtoToProduct();

            var result = await _productRepo.AddProductAsync(product);

            return Ok(result);
        }

        [HttpGet("get_product_by_category/{id}")]
        public async Task<IActionResult> GetProductByCategoryId([FromRoute] int id)
        {
            var result = await _productRepo.GetProductByCategoryIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result.Select(r => r.ToProductDto()));
        }

        [HttpGet("get_product_by_id/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var result = await _productRepo.GetProductByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result.ToProductDto());
        }
    }
}