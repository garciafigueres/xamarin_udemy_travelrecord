using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_udemy_travelrecordapp.Model;

namespace xamarin_udemy_travelrecordapp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static MobileServiceClient MobileService = new MobileServiceClient("https://gftravelrecordappxam.azurewebsites.net");
        public static User user = new User();

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
