using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{
    // Get: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = userRepository.GetUsersAsync();

        var usersToReturn = mapper.Map<MemberDto>(users);

        return Ok(users);
    }
    // Get: api/users/{id}
    [HttpGet("{username}")]
    public async Task<ActionResult<AppUser>> GetUserByUsername(string username)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();

        return user;
    }
    
}
