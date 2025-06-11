using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using animomentapi.Data;
using animomentapi.Dto.User;
using animomentapi.Interface;
using animomentapi.Mapper;
using animomentapi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace animomentapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly string _connectionString;
        public UserRepository(ApplicationDBContext context, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            _context = context;
        }

        public async Task<User?> UserLoginAsync(UserLoginDto dto)
        {
            var result = await _context.Users.Include(c => c.Cart).FirstOrDefaultAsync(f => f.UserName == dto.UserName);

            if (result == null) return null;

            if (dto.PasswordHash == result.PasswordHash)
            {
                return result;
            }

            return null;
        }

        public async Task<User?> AddNewUserAsync(AddUserDto dto)
        {
            var result = dto.ToUserFromAddUserDto();

            await _context.Users.AddAsync(result);

            await _context.SaveChangesAsync();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", result.UserId);

                await db.QueryAsync<User>(
                    "usp_Add_New_User",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }

            return result;
        }

        public async Task<User?> EditUserAsync(int id, EditUserDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null) return null;

            user.UserName = dto.UserName.Trim();
            user.FirstName = dto.FirstName?.Trim();
            user.LastName = dto.LastName?.Trim();
            user.Email = dto.Email?.Trim();
            user.PhoneNumber = dto.PhoneNumber?.Trim();

            await _context.SaveChangesAsync();

            return user;
        }
    }
}