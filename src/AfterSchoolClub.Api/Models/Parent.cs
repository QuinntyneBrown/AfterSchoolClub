using System;
using System.Collections.Generic;

namespace AfterSchoolClub.Api.Models
{
    public class Parent
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public List<Child> Children { get; private set; } = new();
        public Parent()
        {

        }
    }
}
