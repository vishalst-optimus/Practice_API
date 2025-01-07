using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.Interfaces;
using Practice.Application.Queries;
using Practice.Domain.Entities;

namespace Practice.Application.Handlers
{
    public class GetEmployeesByDepartmentIdQueryHandler : IRequestHandler<GetEmployeesByDepartmentIdQuery, IEnumerable<Employee>>
    {
        private readonly IDepartmentRepository departmentRepository;
        public GetEmployeesByDepartmentIdQueryHandler(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<Employee>> Handle(GetEmployeesByDepartmentIdQuery request, CancellationToken cancellationToken)
        {
            var res = await departmentRepository.GetEmployeesByDepartmentIdAsync(request.departmentId);
            return res;
        }
    }
}
