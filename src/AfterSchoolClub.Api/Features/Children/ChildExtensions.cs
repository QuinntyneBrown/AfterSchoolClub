using System;
using AfterSchoolClub.Api.Models;

namespace AfterSchoolClub.Api.Features
{
    public static class ChildExtensions
    {
        public static ChildDto ToDto(this Child child)
        {
            return new ()
            {
                ChildId = child.ChildId
            };
        }
        
    }
}
