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
        User user;

        public RegisterPage()
        {
            InitializeComponent();

            user = new User();
            containerStackLayout.BindingContext = user;
        }

        private async Task RegisterUser()
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                // Como tenemos el StackLayout bindeado, no hace falta esto.
                //Users user = new Users()
                //{
                //    Email = emailEntry.Text,
                //    Password = passwordEntry.Text
                //};

                User.Register(user);
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