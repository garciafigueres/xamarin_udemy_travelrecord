using Plugin.Geolocator;
using SQLite;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_udemy_travelrecordapp.Logic;
using xamarin_udemy_travelrecordapp.Model;

namespace xamarin_udemy_travelrecordapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            // Con el bloque using nos aseguramos de que se llama al método dispose al salir
            // del mismo, ya que la clase SQLiteConnection ya incluye la interfaz IDisposable.
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);
                conn.Close();

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully inserted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }
                
        }
    }
}