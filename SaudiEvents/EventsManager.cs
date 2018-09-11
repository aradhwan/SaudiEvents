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

        private List<Event> events;

        public EventsManager()
        {
            eventService = new SaudiEventsService();
        }

        public async Task<List<Event>> GetEvents (DateTime from, DateTime to)
        {
            events = await eventService.GetEvents(from, to);
            return events.OrderByDescending(x => x.EventStartDate).ToList();
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

        public List<Event> SortAscending()
        {
            return events.OrderBy(x => x.EventStartDate).ToList();
        }

        public List<Event> SortDescending()
        {
            return events.OrderByDescending(x => x.EventStartDate).ToList();
        }
    }
}
