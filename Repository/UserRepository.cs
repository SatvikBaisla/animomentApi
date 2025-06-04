using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Data;
using animomentapi.Dto.User;
using animomentapi.Interface;
using animomentapi.Models;
using Microsoft.EntityFrameworkCore;

namespace animomentapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
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
    }
}