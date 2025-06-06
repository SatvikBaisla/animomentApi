using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.User;
using animomentapi.Models;

namespace animomentapi.Interface
{
    public interface IUserRepository
    {
        Task<User?> UserLoginAsync(UserLoginDto dto);
        Task<User?> AddNewUserAsync(AddUserDto dto);
    }
}