using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;

namespace Practice.Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly PracticeDbContext _context;
        public DepartmentRepository(PracticeDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>?> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            var res = await GetByIdAsync(departmentId);
            var employees = res?.Employees?.ToList();
            return employees;
        }
    }
}
