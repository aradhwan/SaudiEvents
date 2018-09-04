using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using SaudiEvents.Views;
using System.Windows.Input;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace SaudiEvents.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        //public INavigation Navigation { get; private set; }
        //public ICommand ShowEventsCommand { get; private set; }

        private DelegateCommand _showEventsCommand;
        public DelegateCommand ShowEventsCommand => _showEventsCommand ?? (_showEventsCommand = new DelegateCommand(OnShowEventsCommandExecuted, CanShowEventsCommand));

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            //this.Navigation = navigation;
            //this.ShowEventsCommand = new Command(async() => await GoToEventsPage());
        }


        private bool CanShowEventsCommand()
        {
            return true;
        }

        private void OnShowEventsCommandExecuted()
        {
            NavigationService.NavigateAsync("EventsPage");
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

        //private async Task ShowEventsCommand()
        //{

        //    //await Navigation.PushAsync(new EventsPage());
        //}
    }
}
