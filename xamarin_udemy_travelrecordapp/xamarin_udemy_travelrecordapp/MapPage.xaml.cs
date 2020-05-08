using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_udemy_travelrecordapp.Model;

namespace xamarin_udemy_travelrecordapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MapPage : ContentPage
    {

        private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
        }

        private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationWhenInUsePermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need location", "We need to acces your location", "OK");
                    }

                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationWhenInUsePermission>();
                }
                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location denied", "You give us permission to acces location, so we can't show you on map", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }

            GetLocation();


            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();

                DisplayInMap(posts);
            }

        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);
                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };

                    locationsMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre)
                {

                    throw;
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //CrossGeolocator.Current.StopListeningAsync();
            //CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;

            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;

            locator.StopListeningAsync();
        }

        private void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);

            locationsMap.MoveToRegion(span);
        }
    }

}