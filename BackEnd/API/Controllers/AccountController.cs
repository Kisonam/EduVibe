using Microsoft.AspNetCore.Mvc;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    public class AccountController(UserManager<AppUser> userManager, 
    ITokenService tokenService, IMapper mapper) : BaseApiController
    {
        // POST: api/account/register
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
                return BadRequest("Username already exists");

            var user = mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.Username.ToLower();
            user.Email = registerDto.Email;

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }

        // POST: api/account/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null || user.UserName == null) 
                return Unauthorized("Incorrect username");
            
            var result = await userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized("Incorrect password");

            return new UserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await userManager.Users.AnyAsync(x => x.NormalizedUserName == username.ToUpper());
        }
    }
}
