using System;

namespace AfterSchoolClub.Api.Models
{
    public class Event
    {
        public Guid EventId { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public Location Location { get; private set; }
        public Event(DateTime date, string name)
        {
            Date = date;
            Name = name;
        }

        private Event()
        {

        }
    }
}
