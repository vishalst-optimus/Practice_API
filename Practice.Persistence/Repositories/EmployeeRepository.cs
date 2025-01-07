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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly PracticeDbContext _context;
        public EmployeeRepository(PracticeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>?> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            var res = await _context.Employees.Where(x => x.DepartmentId == departmentId).ToListAsync();
            return res;
        }

        public async Task<IEnumerable<Project>> GetProjectsByEmployeeIdAsync(int employeeId)
        {
            var res = await GetByIdAsync(employeeId);
            var projects = res?.Projects?.ToList();
            return projects;
        }

        public async Task<bool> AddProjectsToEmployeeAync(int employeeId, List<int>? projects)
        {
            //Get employee by id
            var res = await GetByIdAsync(employeeId);
            if (res == null) return false;

            //Get projects by id for each projectid in the list
            var projectList = await _context.Projects.Where(x => projects.Contains(x.Id)).ToListAsync();

            //Add projects to employee
            foreach (var project in projectList)
            {
                if (!res.Projects.Contains(project))
                {
                    res.Projects.Add(project);
                }
            }

            await _context.SaveChangesAsync();

            return true;
        }

    } 
}
