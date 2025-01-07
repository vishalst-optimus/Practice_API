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
    public class DepartmentController : Controller
    {
        private readonly PracticeDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper mapper;

        public DepartmentController(PracticeDbContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDTO department)
        {
            var dept = mapper.Map<Department>(department);
            var input = new CreateCommand<Department>(dept);
            var res = await _mediator.Send(input);
            var ans = mapper.Map<DepartmentDTO>(res);
            return Ok(ans);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var res = await _mediator.Send(new DeleteCommand<Department>(id));
            if (res == false)
            {
                return BadRequest("Employee Not found !!");
            }
            return Ok("Employee Deleted Successfully !!");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartment([FromRoute] int id)
        {
            var input = new GetQuery<Department>(id);
            var res = await _mediator.Send(input);
            if (res == null)
            {
                return BadRequest("Employee Not found !!");
            }
            var ans = mapper.Map<DepartmentDTO>(res);
            return Ok(ans);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var res = await _mediator.Send(new GetAllDataQuery<Department>());
            return Ok(res);
        }

        [HttpGet("{departmentId:int}/employees")]
        public async Task<IActionResult> GetEmployeesByDepartmentId([FromRoute] int departmentId)
        {
            var res = await _mediator.Send(new GetEmployeesByDepartmentIdQuery(departmentId));
            if (res == null)
            {
                return BadRequest("Employees Not found !!");
            }
            return Ok(res);
        }
    }
}
