using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SaudiEvents.Views;
using SaudiEvents.ViewModels;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Prism.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace SaudiEvents
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<EventsPage>();
        }

        //public App()
        //{
        //    InitializeComponent();

        //    var nav = new NavigationPage(new HomePage());
        //    nav.BarTextColor = Color.White;
        //    nav.BarBackgroundColor = Color.FromHex("490848");

        //    MainPage = nav;
        //}
    }
}
