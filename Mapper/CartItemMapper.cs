using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.CartItem;
using animomentapi.Models;

namespace animomentapi.Mapper
{
    public static class CartItemMapper
    {
        public static CartItem FromAddCartItemDtoToCartItem(this AddCartItemDto dto)
        {
            return new CartItem
            {
                CartId = dto.CartId,
                ProductId = dto.ProductId,
            };
        }
    }
}