using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;

namespace Practice.Persistence.Repositories
{
    public class EmployeeProfileRepository : GenericRepository<EmployeeProfile>, IEmployeeProfileRepository
    {
        private readonly PracticeDbContext _context;
        public EmployeeProfileRepository(PracticeDbContext _context) : base(_context)
        {
        }
    }
}
