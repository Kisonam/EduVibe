using System;
using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
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
    public async Task<ActionResult> UpdateUser(MemberUpdateDto member)
    {

        var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());

        if (user == null) return BadRequest("User not found");

        mapper.Map(member, user);

    

        if (await userRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update user");

    }

    [HttpPost("add-photo")]
    public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
    {
        var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());

        if (user == null) return BadRequest("User cannot be update");

        var result = await photoSevice.AddPhotoAsync(file);

        if (result == null) return BadRequest("Failed to upload photo");

        var photo = new Photo{
            Url = result.SecureUrl.AbsoluteUri,
            PublicId = result.PublicId
        };

       user.Photos.Add(photo);

        if (await userRepository.SaveAllAsync()) 
            return CreatedAtAction(nameof(GetUserByUsername),
            new {username = user.UserName},
            mapper.Map<PhotoDto>(photo));

            
            
        return BadRequest("Failed to add photo");
    }
    [HttpDelete("delete-photo/{photoId}")]
    public async Task<ActionResult> DeletePhoto(int photoId)
    {
        var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());

        if (user == null) return BadRequest("User cannot be deleted");

        var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

        if (photo.IsMain || photo == null) return BadRequest("You cannot delete your main photo");

        if (photo.PublicId != null)
        {
            var result = await photoSevice.DeletionResultAsync(photo.PublicId);
            if (result.Error != null) return BadRequest(result.Error.Message);
        }
        user.Photos.Remove(photo);

        if (await userRepository.SaveAllAsync()) return Ok();

        return BadRequest("Failed to delete photo");
    }


}
