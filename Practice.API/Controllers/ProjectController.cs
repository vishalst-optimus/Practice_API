using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Application.Commands;
using Practice.Application.DTO;
using Practice.Application.Interfaces;
using Practice.Application.Queries;
using Practice.Domain.Entities;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IProjectRepository projectRepository;
        public ProjectController(IMediator mediator, IMapper mapper, IProjectRepository projectRepository)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.projectRepository = projectRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            var project = await mediator.Send(new GetQuery<Project>(id));
            if (project == null)
            {
                return BadRequest("Project Not found !!");
            }
            var response = mapper.Map<ProjectDTO>(project);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDTO projectDTO)
        {
            var project = mapper.Map<Project>(projectDTO);
            var response = await mediator.Send(new CreateCommand<Project>(project));
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var response = await mediator.Send(new DeleteCommand<Project>(id));
            return Ok(response);
        }

        [HttpPost("{projectId:int}/employees")]
        public async Task<IActionResult> AddEmployeesToProject([FromRoute] int projectId, [FromBody] List<int> employeeIds)
        {
            var response = await mediator.Send(new AddEmployeesToProjectCommand(projectId, employeeIds));
            if (response == false)
            {
                return BadRequest("Project Not found !!");
            }
            return Ok("Employees added to project successfully !!");
        }

        [HttpGet("{projectId:int}/employees")]
        public async Task<IActionResult> GetEmployeesByProjectId([FromRoute] int projectId)
        {
            var employees = await projectRepository.GetEmployeesByProjectIdAsync(projectId);
            if (employees == null)
            {
                return BadRequest("Employees Not found !!");
            }
            return Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await mediator.Send(new GetAllDataQuery<Project>());
            return Ok(projects);
        }
    }
}
