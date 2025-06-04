using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.Category;
using animomentapi.Models;

namespace animomentapi.Interface
{
    public interface IProductCategoriesRepository
    {
        Task<List<ProductCategory>?> GetAllProductAsync();
        Task<ProductCategory?> GetCategoryByIdAsync(int id);
        Task<ProductCategory?> EditCategoryAsync(int id, UpdateCategoryDto dto);
    }
}