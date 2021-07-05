using System;
using AfterSchoolClub.Api.Models;

namespace AfterSchoolClub.Api.Features
{
    public static class ParentExtensions
    {
        public static ParentDto ToDto(this Parent parent)
        {
            return new ()
            {
                ParentId = parent.ParentId
            };
        }
        
    }
}
