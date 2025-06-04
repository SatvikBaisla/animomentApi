using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.CartItem;
using animomentapi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace animomentapi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepo;

        public CartItemController(ICartItemRepository cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }

        [HttpGet("get_all_cart_items/{userId}")]
        public async Task<IActionResult> GetAllCartItems([FromRoute] int userId)
        {
            var result = await _cartItemRepo.GetCartItemAsync(userId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("add_new_cart_item")]
        public async Task<IActionResult> AddCartItem([FromBody] AddCartItemRequestDto dto)
        {
            var result = await _cartItemRepo.AddCartItemAsync(dto);

            return Ok(result);
        }

        [HttpDelete("delete_cart_item/{id}")]
        public async Task<IActionResult> DeleteCartItem([FromRoute] int id)
        {
            var result = await _cartItemRepo.DeleteCartItemAsync(id);

            if (result == null) return NotFound();

            return Ok();
        }
    }
}