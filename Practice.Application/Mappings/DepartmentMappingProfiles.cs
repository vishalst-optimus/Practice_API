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
    public class DepartmentMappingProfiles : Profile
    {
        public DepartmentMappingProfiles()
        {
            CreateMap<DepartmentDTO, Department>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();
        }
    }
}
