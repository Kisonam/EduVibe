using System;
using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper, IPhotoSevice photoSevice) : BaseApiController
{
    // Get: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();
        return Ok(users);
    }
    // Get: api/users/{username}
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
    {
        var user = await userRepository.GetMemberAsync(username);
        if (user == null) return NotFound();

        return user;
    }


    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto member){
       
       var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

       if (userName == null) return BadRequest("No username found in token");

       var user = await userRepository.GetUserByUsernameAsync(userName);

       if (user == null) return BadRequest("User not found");

        mapper.Map(member, user);
        
        if(await userRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update user");

    }
    
}
