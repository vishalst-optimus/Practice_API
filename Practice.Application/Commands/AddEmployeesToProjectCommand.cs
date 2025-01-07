using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Practice.Application.Commands
{
    public class AddEmployeesToProjectCommand : IRequest<bool>
    {
        public int id;
        public List<int>? employeeIds;
        public AddEmployeesToProjectCommand(int id, List<int>? employeeIds)
        {
            this.id = id;
            this.employeeIds = employeeIds;
        }
    }
}
