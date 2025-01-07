using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Practice.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Multiple employees in one department
        //One to Many

        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }

    }
}
