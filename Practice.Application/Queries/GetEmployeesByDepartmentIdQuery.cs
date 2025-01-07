using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Domain.Entities;

namespace Practice.Application.Queries
{
    public class GetEmployeesByDepartmentIdQuery : IRequest<IEnumerable<Employee>>
    {
        public int departmentId;
        public GetEmployeesByDepartmentIdQuery(int departmentId)
        {
            this.departmentId = departmentId;
        }
    }
}
