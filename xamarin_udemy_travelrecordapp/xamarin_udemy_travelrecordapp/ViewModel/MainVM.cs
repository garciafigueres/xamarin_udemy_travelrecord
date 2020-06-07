using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using xamarin_udemy_travelrecordapp.Model;
using xamarin_udemy_travelrecordapp.ViewModel.Commands;

namespace xamarin_udemy_travelrecordapp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private Users user;

        public Users User {
            get { return user; }
            set {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterNavigationCommand RegisterNavigationCommand { get; set; }

        public LoginCommand LoginCommand { get; set; }


        private string email;

        public string Email {
            get { return email; }
            set {
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password {
            get { return password; }
            set {
                password = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainVM()
        {
            User = new Users();
            LoginCommand = new LoginCommand(this);
            RegisterNavigationCommand = new RegisterNavigationCommand(this);
        }

        public async void Login()
        {
            bool canLogin = await Users.Login(User.Email, User.Password);

            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Try Again", "Ok");
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
