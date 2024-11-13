using System;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.GetAge()))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos));
            
            CreateMap<Photo, PhotoDto>();
        }
}
