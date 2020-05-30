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
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;

        public PostDetailPage()
        {

        }

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            
            experienceEntry.Text = selectedPost.Experience;
            venueLabel.Text = selectedPost.VenueName;
            categoryLabel.Text = selectedPost.CategoryName;
            addressLabel.Text = selectedPost.Address;
            coordinatesLabel.Text = $"{selectedPost.Latitude},{selectedPost.Longitude}";
            distanceLabel.Text = $"{selectedPost.Distance} m";
        }

        

        private async void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    int rows = conn.Update(selectedPost);
            //    conn.Close();

            //    if (rows > 0)
            //        DisplayAlert("Success", "Experience succesfully updated", "Ok");
            //    else
            //        DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            //}

            await App.MobileService.GetTable<Post>().UpdateAsync(selectedPost);
            await DisplayAlert("Success", "Experience succesfully updated", "Ok");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    int rows = conn.Delete(selectedPost);
            //    conn.Close();

            //    if (rows > 0)
            //        DisplayAlert("Success", "Experience succesfully deleted", "Ok");
            //    else
            //        DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
            //}

            await App.MobileService.GetTable<Post>().DeleteAsync(selectedPost);
            await DisplayAlert("Success", "Experience succesfully deleted", "Ok");
        }
    }
}