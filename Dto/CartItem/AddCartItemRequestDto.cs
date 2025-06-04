using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animomentapi.Dto.CartItem
{
    public class AddCartItemRequestDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}