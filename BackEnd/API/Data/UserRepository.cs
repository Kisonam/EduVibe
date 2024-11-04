using System;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await context.Users
        .FindAsync(id);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty", nameof(username));
        }
        
        try
        {
            return await context.Users
            .Include(u => u.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it accordingly
            throw new InvalidOperationException("An error occurred while retrieving the user", ex);
        }
    }


    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await context.Users
        .Include(u => u.Photos)
        .ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(AppUser user)
    {
       context.Entry(user).State = EntityState.Modified;
    }
}
