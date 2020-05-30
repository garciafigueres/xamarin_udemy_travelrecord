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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async Task RegisterUser()
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                Users user = new Users()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text
                };

                //await App.MobileService.GetTable<Users>().InsertAsync(user);
                Users.Register(user);

            }
            else
            {
                await DisplayAlert("Error", "Passwords don't match.", "OK");
            }
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            await RegisterUser();
        }
    }
}