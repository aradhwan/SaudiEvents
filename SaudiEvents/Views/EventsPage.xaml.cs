using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SaudiEvents.ViewModels;
using System.Threading.Tasks;

namespace SaudiEvents.Views
{
    public partial class EventsPage : ContentPage
    {
        public EventsPage()
        {
            InitializeComponent();

        }
		protected override void OnAppearing()
		{
            
            BindingContext = new EventsPageViewModel();
            IsBusy = false;
		}
	}
}
