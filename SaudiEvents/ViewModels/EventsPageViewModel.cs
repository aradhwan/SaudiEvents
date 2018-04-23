using System;
using System.Collections.Generic;
using SaudiEvents.Models;

namespace SaudiEvents.ViewModels
{
    public class EventsPageViewModel : BaseViewModel
    {
        private EventsManager eventsManager;
        private List<Event> eventsList;
        private string searchText;

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    RaisePropertyChanged("SearchText");
                    Events = eventsManager.SearchEvents(value);
                }
            }
        }

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
