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

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
