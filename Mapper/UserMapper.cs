using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.User;
using animomentapi.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace animomentapi.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User model)
        {
            return new UserDto
            {
                UserId = model.UserId,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}