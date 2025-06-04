using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Data;
using animomentapi.Dto.Category;
using animomentapi.Interface;
using animomentapi.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace animomentapi.Repository
{
    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductCategoriesRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<ProductCategory>?> GetAllProductAsync()
        {
            var result = await _context.ProductCategories.ToListAsync();
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<ProductCategory?> GetCategoryByIdAsync(int id)
        {
            var result = await _context.ProductCategories.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (result == null) return null;
            else return result;
        }

        public async Task<ProductCategory?> EditCategoryAsync(int id, UpdateCategoryDto dto)
        {
            var result = await _context.ProductCategories.FirstOrDefaultAsync(c => c.CategoryId == id);

            if (result == null) return null;

            result.CategoryName = dto.CategoryName.Trim();
            result.FilterName = dto.FilterName.Trim();
            result.ImgUrl = dto.ImgUrl?.Trim();

            await _context.SaveChangesAsync();
            return result;
        }
    }

}