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
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<ProjectDTO, Project>().ReverseMap();
        }
    }
}
