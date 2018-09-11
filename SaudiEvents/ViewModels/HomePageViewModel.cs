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

        private DateTime _fromDate { get; set; }
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    RaisePropertyChanged(nameof(FromDate));
                }
            }
        }

        private DateTime _toDate { get; set; }
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    RaisePropertyChanged(nameof(ToDate));
                }
            }
        }

        public DelegateCommand ShowEventsCommand { get; private set; }

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            //this.Navigation = navigation;
            //this.ShowEventsCommand = new Command(async() => await GoToEventsPage());
            FromDate = DateTime.Today;
            ToDate = DateTime.Today;
            ShowEventsCommand = new DelegateCommand(OnShowEventsCommandExecuted);
        }


        private void OnShowEventsCommandExecuted()
        {
            NavigationParameters navParameters = new NavigationParameters();
            navParameters.Add("FromDate", _fromDate);
            navParameters.Add("ToDate", _toDate);
            NavigationService.NavigateAsync("EventsPage",navParameters);
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
