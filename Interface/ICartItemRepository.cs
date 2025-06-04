using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.CartItem;
using animomentapi.Models;

namespace animomentapi.Interface
{
    public interface ICartItemRepository
    {
        Task<List<CartItemDto>?> GetCartItemAsync(int id);
        Task<CartItem?> AddCartItemAsync(AddCartItemRequestDto dto);
        Task<CartItem?> DeleteCartItemAsync(int id);
    }
}