using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animomentapi.Dto.CartItem
{
    public class CartItemDto // form stored procedure 
    {
        public int? UserId { get; set; }
        public int? CartId { get; set; }
        public int? ItemId { get; set; }
        public int? ProductId { get; set; }
        public string? ArticleNumber { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? ImgUrl { get; set; }
    }
}