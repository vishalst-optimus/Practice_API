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
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
            .ForMember(dest => dest.EmployeeProfileId, opt => opt.MapFrom(src => src.EmployeeProfileId)).ReverseMap();
        }
    }
}
