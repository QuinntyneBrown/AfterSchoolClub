using System;
using AfterSchoolClub.Api.Models;

namespace AfterSchoolClub.Api.Features
{
    public static class LocationExtensions
    {
        public static LocationDto ToDto(this Location location)
        {
            return new ()
            {
                LocationId = location.LocationId
            };
        }
        
    }
}
