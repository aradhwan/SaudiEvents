using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using SaudiEvents.Views;
using System.Windows.Input;

namespace SaudiEvents.ViewModels
{
    public class HomePageViewModel
    {
        public INavigation Navigation { get; private set; }
        public ICommand ShowEventsCommand { get; private set; }

        public HomePageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.ShowEventsCommand = new Command(async() => await GoToEventsPage());
            //this.ShowEventsCommand = new Command(async (parameter) => await GoToEventsPage());
        }

        //private async Task GoToEventsPage()
        //{
        //    switch (obj)
        //    {
        //        case "Events":
        //            await Navigation.PushAsync(new EventsPage());
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private async Task GoToEventsPage()
        {
            await Navigation.PushAsync(new EventsPage());
        }
    }
}
