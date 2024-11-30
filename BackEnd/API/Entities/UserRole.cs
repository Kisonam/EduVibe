using System;
using Microsoft.AspNetCore.Identity;

namespace API.Entities;

public class UserRole : IdentityUserRole<int>
{
    public AppUser? AppUser { get; set; }
    public AppRole? AppRole { get; set; }
}
