using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Practice.Application.DTO;
using Practice.Domain.Entities;

namespace Practice.Application.Mappings
{
    public class EmployeeProfileMappingProfile : Profile
    {
        public EmployeeProfileMappingProfile()
        {
            CreateMap<EmployeeProfile, EmployeeProfileDTO>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl)).ReverseMap();
        }
    }
}
