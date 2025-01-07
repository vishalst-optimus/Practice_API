using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Application.Commands;
using Practice.Application.DTO;
using Practice.Application.Queries;
using Practice.Domain.Entities;
using Practice.Persistence;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProfileController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly PracticeDbContext dbContext;

        public EmployeeProfileController(IMediator mediator, IMapper mapper, PracticeDbContext dbContext)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeProfile([FromBody] EmployeeProfileDTO employeeProfile)
        {
            var employeeProfileEntity = mapper.Map<EmployeeProfile>(employeeProfile);
            var result = await mediator.Send(new CreateCommand<EmployeeProfile>(employeeProfileEntity));
            var response = mapper.Map<EmployeeProfileDTO>(result);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeProfile([FromRoute] int id)
        {
            var employeeProfile = await mediator.Send(new GetQuery<EmployeeProfile>(id));
            if (employeeProfile == null)
            {
                return BadRequest("Employee Profile Not found !!");
            }
            var response = mapper.Map<EmployeeProfileDTO>(employeeProfile);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeProfiles()
        {
            var employeeProfiles = await mediator.Send(new GetAllDataQuery<EmployeeProfile>());
            return Ok(employeeProfiles);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployeeProfile([FromRoute] int id)
        {
            var result = await mediator.Send(new DeleteCommand<EmployeeProfile>(id));
            if (result == false)
            {
                return BadRequest("Employee Profile Not found !!");
            }
            return Ok("Employee Profile Deleted Successfully !!");
        }
    }
}
