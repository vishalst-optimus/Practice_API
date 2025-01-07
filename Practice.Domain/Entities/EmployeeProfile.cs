﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Practice.Domain.Entities
{
    public class EmployeeProfile
    {
        public int Id { get; set; } 
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }

        //One employee will have only one profile
        //One to One

        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}
