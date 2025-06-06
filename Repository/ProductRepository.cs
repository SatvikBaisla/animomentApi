using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Data;
using animomentapi.Interface;
using animomentapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace animomentapi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Product>?> GetAllProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> AddProductAsync(Product model)
        {
            var result = model;

            await _context.Products.AddAsync(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<Product>?> GetProductByCategoryIdAsync(int id)
        {
            var result = await _context.Products.Where(p => p.CategoryId == id).ToListAsync();

            if (result == null) return null;

            return result;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

            if (result == null) return null;

            return result;
        }
    }
}