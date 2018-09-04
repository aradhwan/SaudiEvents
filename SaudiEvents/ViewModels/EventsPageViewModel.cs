using System;
using System.Collections.Generic;
using Prism.Navigation;
using SaudiEvents.Models;

namespace SaudiEvents.ViewModels
{
    public class EventsPageViewModel : ViewModelBase
    {
        private EventsManager eventsManager;
        private List<Event> _events;
        private string _searchText;

        public EventsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            eventsManager = new EventsManager();
            _events = eventsManager.Events;
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    RaisePropertyChanged("SearchText");
                    Events = eventsManager.SearchEvents(value);
                }
            }
        }

        public List<Event> Events
        {
            get => _events;
            set { _events = value; RaisePropertyChanged(nameof(Events)); }
        }
    }
}
