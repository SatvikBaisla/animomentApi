using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Models;

namespace animomentapi.Dto.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
    }
}