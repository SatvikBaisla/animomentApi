using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animomentapi.Dto.User
{
    public class AddUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}