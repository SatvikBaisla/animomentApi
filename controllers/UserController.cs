using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using animomentapi.Dto.User;
using animomentapi.Interface;
using animomentapi.Mapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace animomentapi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginDto dto)
        {
            var result = await _userRepo.UserLoginAsync(dto);

            if (result == null) return NotFound();

            return Ok(result.ToUserDto());
        }

        [HttpPost("add_new_user")]
        public async Task<IActionResult> AddNewUser([FromBody] AddUserDto dto)
        {
            var result = await _userRepo.AddNewUserAsync(dto);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPut("edit_user_by_id/{id}")]
        public async Task<IActionResult> EditUser([FromRoute] int id, [FromBody] EditUserDto dto)
        {
            var result = await _userRepo.EditUserAsync(id, dto);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}