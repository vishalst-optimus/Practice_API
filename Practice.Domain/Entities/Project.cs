using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Practice.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //One project can have multiple employees associated
        //Many to Many

        
        public virtual ICollection<Employee>? Employees { get; set; }

    }
}
