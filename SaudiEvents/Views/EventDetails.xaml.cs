using System;
using System.Collections.Generic;
using Prism.Navigation;
using SaudiEvents.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SaudiEvents.Views
{
    public partial class EventDetails : ContentPage, INavigationAware
    {
        private Event _currentEvent { get; set; }
        public Event CurrentEvent
        {
            get { return _currentEvent; }
            set => _currentEvent = value;
        }

        public EventDetails()
        {
            InitializeComponent();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Event"))
            {
                CurrentEvent = (Event)parameters["Event"];
                gotoLocation(CurrentEvent);
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        private void gotoLocation(Event e)
        {
            double latitude = Convert.ToDouble(e.EventLatitude);
            double longitude = Convert.ToDouble(e.EventLongitude);
            EventMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromKilometers(2)));
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(latitude, longitude),
                Label = e.EventTitle,
                Address = e.CityEnName + ", " + e.RegionEnName + ", " + "Saudi Arabia"
            };
            EventMap.Pins.Add(pin);
        }
    }
}
