using System;
using System.Collections.Generic;
using SaudiEvents.Models;

namespace SaudiEvents.ViewModels
{
    public class EventsPageViewModel : BaseViewModel
    {
        private EventsManager eventsManager;
        private List<Event> eventsList;

        public List<Event> Events 
        {
            get => eventsList;  
            set { eventsList = value; RaisePropertyChanged(nameof(Events)); }
        }

        public EventsPageViewModel()
        {
            eventsManager = new EventsManager();
            Events = eventsManager.Events;
        }
    }
}
