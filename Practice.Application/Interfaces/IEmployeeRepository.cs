using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Domain.Entities;

namespace Practice.Application.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>?> GetEmployeeByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<Project>> GetProjectsByEmployeeIdAsync(int employeeId);
        Task<bool> AddProjectsToEmployeeAync(int employeeId, List<int>? projects);
    }
}
