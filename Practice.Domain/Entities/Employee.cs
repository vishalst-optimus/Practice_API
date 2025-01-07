using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Practice.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        //ForeignKey
        public int? DepartmentId { get; set; }

        //Foreign Key
        public int? EmployeeProfileId { get; set; }

        //One employee belongs to only one department
        //One to One
        public virtual Department? Department { get; set; }  //Foreign Key to department

        //One employee can be a part of any number of projects
        //Many to Many

        [JsonIgnore]
        public virtual ICollection<Project>? Projects { get; set; }

        public virtual EmployeeProfile? EmployeeProfile { get; set; }
    }
}
