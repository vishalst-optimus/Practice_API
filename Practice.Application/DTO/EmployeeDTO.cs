using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Application.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        //ForeignKey
        public int? DepartmentId { get; set; }

        //Foreign Key
        public int? EmployeeProfileId { get; set; }

        //Foreign Key
        //public int? EmployeeProfileId { get; set; }

    }
}
