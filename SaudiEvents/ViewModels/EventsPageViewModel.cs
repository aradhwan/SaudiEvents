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

        private DateTime _fromDate { get; set; }
        private DateTime _toDate { get; set; }

        private Event _selectedEvent { get; set; }
        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                if(_selectedEvent != value)
                {
                     _selectedEvent = value;
                    RaisePropertyChanged(nameof(SelectedEvent));
                    HandleSelectedEvent();
                }
            }
        }

        private async void HandleSelectedEvent()
        {
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Event", _selectedEvent);
            await NavigationService.NavigateAsync("EventDetails", pairs);
        }

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

        public DelegateCommand RefreshCommand { get; private set; }

        private async void OnRefreshCommandExecuted()
        {
            IsRefreshing = true;

            SearchText = String.Empty;
            Events = await eventsManager.GetEvents(_fromDate,_toDate);
            Events = eventsManager.SortAscending();
            IsRefreshing = false;
        }

        public EventsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            eventsManager = new EventsManager();
            // _events = eventsManager.Events;
            RefreshCommand = new DelegateCommand(OnRefreshCommandExecuted);
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

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.GetNavigationMode() == NavigationMode.New)
            {
                _fromDate = (DateTime)parameters["FromDate"];
                _toDate = (DateTime)parameters["ToDate"];
                RefreshCommand.Execute();
            }
            base.OnNavigatedTo(parameters);
        }
    }
}
