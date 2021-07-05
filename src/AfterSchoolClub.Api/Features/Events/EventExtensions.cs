using System;
using AfterSchoolClub.Api.Models;

namespace AfterSchoolClub.Api.Features
{
    public static class EventExtensions
    {
        public static EventDto ToDto(this Event @event)
        {
            return new ()
            {
                EventId = @event.EventId
            };
        }
        
    }
}
