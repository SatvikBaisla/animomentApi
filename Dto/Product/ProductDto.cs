using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animomentapi.Dto.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int ArticleNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
        public string? ImgUrl2 { get; set; }
        public string? ImgUrl3 { get; set; }
        public string? ImgUrl4 { get; set; }
        public string? ImgUrl5 { get; set; }
    }
}