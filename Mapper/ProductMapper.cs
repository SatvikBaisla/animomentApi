using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.Product;
using animomentapi.Models;

namespace animomentapi.Mapper
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product model)
        {
            return new ProductDto
            {
                ProductId = model.ProductId,
                CategoryId = model.CategoryId,
                ArticleNumber = model.ArticleNumber,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                ImgUrl = model.ImgUrl,
                ImgUrl2 = model.ImgUrl2,
                ImgUrl3 = model.ImgUrl3,
                ImgUrl4 = model.ImgUrl4,
                ImgUrl5 = model.ImgUrl5,
            };
        }

        public static Product FromDtoToProduct(this AddProductDto dto)
        {
            return new Product
            {
                CategoryId = dto.CategoryId,
                ArticleNumber = dto.ArticleNumber,
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                ImgUrl = dto.ImgUrl,
                ImgUrl2 = dto.ImgUrl2,
                ImgUrl3 = dto.ImgUrl3,
                ImgUrl4 = dto.ImgUrl4,
                ImgUrl5 = dto.ImgUrl5,
            };
        }
    }
}