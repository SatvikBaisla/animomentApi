using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.CartItem;
using animomentapi.Interface;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using animomentapi.Data;
using Microsoft.EntityFrameworkCore;
using animomentapi.Models;

namespace animomentapi.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly string _connectionString;
        private readonly ApplicationDBContext _context;
        public CartItemRepository(IConfiguration configuration, ApplicationDBContext context)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            _context = context;
        }

        public async Task<List<CartItemDto>?> GetCartItemAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", id);

                var result = await db.QueryAsync<CartItemDto>(
                    "usp_Get_All_Cart_Items",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (result == null) return null;

                return result.ToList();
            }
        }

        public async Task<CartItem?> AddCartItemAsync(AddCartItemRequestDto dto)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == dto.UserId);

            var cartItem = new CartItem
            {
                CartId = cart?.CartId,
                ProductId = dto.ProductId
            };

            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            return cartItem;
        }

        public async Task<CartItem?> DeleteCartItemAsync(int id)
        {
            var result = await _context.CartItems.FirstOrDefaultAsync(i => i.ItemId == id);

            if (result == null) return null;

            _context.CartItems.Remove(result);

            await _context.SaveChangesAsync();

            return result;
        }
    }
}