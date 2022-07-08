using AutoMapper;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Mappers;

public class RoleAutoMapperProfile : Profile
{
    public RoleAutoMapperProfile()
    {
        CreateMap<RoleDTO, Role>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name));

        CreateMap<Role, RoleDTO>()
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name));
    }
}