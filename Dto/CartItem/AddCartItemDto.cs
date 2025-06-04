using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animomentapi.Dto.CartItem
{
    public class AddCartItemDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}