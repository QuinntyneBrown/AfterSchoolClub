using System;

namespace AfterSchoolClub.Api.Features
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public LocationDto Location { get; set; }
    }
}
