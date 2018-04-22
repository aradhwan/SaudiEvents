using System;
using Xamarin.Forms;
using SaudiEvents.Views;

namespace SaudiEvents
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new HomePage());
            nav.BarTextColor = Color.White;
            nav.BarBackgroundColor = Color.FromHex("490848");

            MainPage = nav;
        }
    }
}
