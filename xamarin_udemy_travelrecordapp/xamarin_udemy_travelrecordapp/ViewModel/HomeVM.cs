using System;
using System.Collections.Generic;
using System.Text;
using xamarin_udemy_travelrecordapp.ViewModel.Commands;

namespace xamarin_udemy_travelrecordapp.ViewModel
{
    public class HomeVM
    {
        public NavigationCommand NavCommand { get; set; }

        public HomeVM()
        {
            NavCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }

    /*
    public class HomeVM
    {
        public NavigationCommand NavCommnand { get; set; }

        public HomeVM()
        {
            NavCommnand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
    */
}
