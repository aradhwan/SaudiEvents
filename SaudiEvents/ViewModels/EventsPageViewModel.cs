using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Navigation;
using SaudiEvents.Models;

namespace SaudiEvents.ViewModels
{
    public class EventsPageViewModel : ViewModelBase
    {
        private EventsManager eventsManager;
        private List<Event> _events;

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(nameof(IsRefreshing));
            }
        }

        public DelegateCommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () => 
                {
                    IsRefreshing = true;

                    SearchText = String.Empty;
                    Events = await eventsManager.GetEvents();
                
                    IsRefreshing = false;
                });
            }
        } 

        public EventsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            eventsManager = new EventsManager();
            // _events = eventsManager.Events;
        }

        private string _searchText;
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
