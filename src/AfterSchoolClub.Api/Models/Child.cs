using System;
using System.Collections.Generic;

namespace AfterSchoolClub.Api.Models
{
    public class Child
    {
        public Guid ChildId { get; set; }
        public string Name { get; set; }
        public List<Parent> Parents { get; private set; } = new();
        public Child()
        {

        }
    }
}
