using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using xamarin_udemy_travelrecordapp.Model;
using xamarin_udemy_travelrecordapp.ViewModel;

namespace xamarin_udemy_travelrecordapp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainVM viewModel;

        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            viewModel = new MainVM();
            BindingContext = viewModel;

            iconImage.Source = ImageSource.FromResource("xamarin_udemy_travelrecordapp.Assets.Images.plane.png", assembly);
        }        
    }
}
