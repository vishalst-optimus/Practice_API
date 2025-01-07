using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Application.Commands;
using Practice.Application.DTO;
using Practice.Application.Interfaces;
using Practice.Application.Queries;
using Practice.Domain.Entities;
using Practice.Persistence;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly PracticeDbContext dbContext;
        private readonly IGenericRepository<Employee> employeeGenericRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public EmployeeController(PracticeDbContext practiceDBContext, IEmployeeRepository employeeRepository, IMediator mediator, IMapper mapper, IGenericRepository<Employee> employeeGenericRepository)
        {
            this.dbContext = practiceDBContext;
            this.employeeRepository = employeeRepository;
            this.mediator = mediator;
            this.mapper = mapper;
            this.employeeGenericRepository = employeeGenericRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await mediator.Send(new GetAllDataQuery<Employee>());
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployees(int id)
        {
            var input = new GetQuery<Employee>(id);
            var employees = await mediator.Send(input);
            if (employees == null)
            {
                return BadRequest("Employee Not found !!");
            }
            var result = mapper.Map<EmployeeDTO>(employees);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeDTO empDto)
        {
            var emp = mapper.Map<Employee>(empDto);
            var input = new CreateCommand<Employee>(emp);
            var result = await mediator.Send(input);
            var res = mapper.Map<EmployeeDTO>(result);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromQuery] int id)
        {
            var res = await mediator.Send(new DeleteCommand<Employee>(id));
            if (res == false)
            {
                return BadRequest("Employee Not found !!");
            }
            return Ok("Employee Deleted Successfully !!");
        }

        [HttpGet("/projects/{employeeId:int}")]
        public async Task<IActionResult> GetProjectsByEmployeeId([FromRoute] int employeeId)
        {
            var projects = await employeeRepository.GetProjectsByEmployeeIdAsync(employeeId);
            if (projects == null)
            {
                return BadRequest("Projects Not found !!");
            }
            return Ok(projects);
        }

        [HttpPost("/projects/{employeeId:int}")]
        public async Task<IActionResult> AddProjectsToEmployee([FromRoute] int employeeId, [FromBody] List<int> projects)
        {
            var res = await employeeRepository.AddProjectsToEmployeeAync(employeeId, projects);
            if (res == false)
            {
                return BadRequest("Employee Not found !!");
            }
            return Ok("Projects added to Employee Successfully !!");
        }

    }
}
