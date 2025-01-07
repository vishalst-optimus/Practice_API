using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers
{
    public class AddEmployeesToProjectCommandHandler : IRequestHandler<AddEmployeesToProjectCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;
        public AddEmployeesToProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<bool> Handle(AddEmployeesToProjectCommand request, CancellationToken cancellationToken)
        {
            return await _projectRepository.AddProjectsByEmployeeIdAsync(request.id, request.employeeIds);
        }
    }
}
