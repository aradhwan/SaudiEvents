using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaudiEvents.Models;
using SaudiEvents.Services;

namespace SaudiEvents
{
    public class EventsManager
    {
        private readonly SaudiEventsService eventService;
        private DateTime _fromDate = new DateTime(2017, 7, 27);
        private DateTime _toDate = new DateTime(2017, 12, 31);

        private List<Event> events;

        public DateTime FromDate 
        {
            get { return _fromDate; } 
            set { _fromDate = value; }
        }

        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }

        public EventsManager()
        {
            eventService = new SaudiEventsService();
        }

        public async Task<List<Event>> GetEvents ()
        {
            events = await eventService.GetEvents(this.FromDate, this.ToDate);
            return events;
        }

        public List<Event> SearchEvents(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return events;
            }
            else
            {
                return events.Where(x => x.EventTitle.ToLower().Contains(text.ToLower())).ToList();
            }
        }
    }
}
