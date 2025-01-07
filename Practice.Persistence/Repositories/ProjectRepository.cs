using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;

namespace Practice.Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly PracticeDbContext _context;
        public ProjectRepository(PracticeDbContext _context) : base(_context)
        {
            this._context = _context;
        }
        public async Task<bool> AddProjectsByEmployeeIdAsync(int id, List<int>? employees)
        {
            var project = await GetByIdAsync(id);
            if (project == null) return false;
            //Get employees by id
            var employeeList = await _context.Employees.Where(x => employees.Contains(x.Id)).ToListAsync();
            //Add employees to project
            foreach (var employee in employeeList)
            {
                if (!project.Employees.Contains(employee))
                {
                    project.Employees.Add(employee);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>?> GetEmployeesByProjectIdAsync(int projectId)
        {
            var res = await GetByIdAsync(projectId);
            var employees = res?.Employees?.ToList();
            return employees;
        }

    }
}
