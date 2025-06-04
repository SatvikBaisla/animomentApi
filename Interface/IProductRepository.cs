using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Models;

namespace animomentapi.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>?> GetAllProductAsync();
        Task<Product?> AddProductAsync(Product model);
    }
}