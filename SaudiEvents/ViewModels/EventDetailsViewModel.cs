using System;
using Prism.Navigation;
using SaudiEvents.Models;

namespace SaudiEvents.ViewModels
{
    public class EventDetailsViewModel : ViewModelBase
    {

# region Event Properties

        private Event _currentEvent { get; set; }
        public Event CurrentEvent
        {
            get { return _currentEvent; }
            set => _currentEvent = value;
        }

        private string _imagePath { get; set; }
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    RaisePropertyChanged(nameof(ImagePath));
                }

            }
        }

        private string _eventTitle { get; set; }
        public string EventTitle
        {
            get { return _eventTitle; }
            set 
            {
                if(_eventTitle != value)
                {
                    _eventTitle = value;
                    RaisePropertyChanged(nameof(EventTitle));
                }

            } 
        }

        private string _eventDetails { get; set; }
        public string EventDetails
        {
            get { return _eventDetails; }
            set
            {
                if (_eventDetails != value)
                {
                    _eventDetails = value;
                    RaisePropertyChanged(nameof(EventDetails));
                }

            }
        }

        private DateTime _eventStartDate { get; set; }
        public DateTime EventStartDate
        {
            get { return _eventStartDate; }
            set
            {
                if (_eventStartDate != value)
                {
                    _eventStartDate = value;
                    RaisePropertyChanged(nameof(EventStartDate));
                }

            }
        }

        private DateTime _eventEndDate { get; set; }
        public DateTime EventEndDate
        {
            get { return _eventEndDate; }
            set
            {
                if (_eventEndDate != value)
                {
                    _eventEndDate = value;
                    RaisePropertyChanged(nameof(EventEndDate));
                }

            }
        }

#endregion

        public EventDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Event"))
            {
                _currentEvent = (Event)parameters["Event"];
                EventTitle = _currentEvent.EventTitle;
                ImagePath = _currentEvent.ImagePath;
                EventDetails = _currentEvent.EventDetails;
                EventStartDate = _currentEvent.EventStartDate;
                EventEndDate = _currentEvent.EventEndDate;
            }
            base.OnNavigatedTo(parameters);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public override void Destroy()
        {

        }

    }
}
