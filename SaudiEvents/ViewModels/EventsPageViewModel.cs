using System;
using System.Collections.Generic;
using SaudiEvents.Models;

namespace SaudiEvents.ViewModels
{
    public class EventsPageViewModel
    {
        EventsManager eventsManager;

        public List<Event> Events { get { return eventsManager.Events; } }

        public EventsPageViewModel()
        {
            eventsManager = new EventsManager();
        }
    }

}
