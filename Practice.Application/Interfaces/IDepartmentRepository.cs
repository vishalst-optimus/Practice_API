using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Domain.Entities;

namespace Practice.Application.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<Employee>?> GetEmployeesByDepartmentIdAsync(int departmentId);
    }
}
