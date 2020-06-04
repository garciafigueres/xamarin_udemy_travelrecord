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
        private User user;

        public User User {
            get { return user; }
            set {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public LoginCommand LoginCommand { get; set; }


        private string email;

        public string Email {
            get { return email; }
            set {
                email = value;
                User = new User()
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
                User = new User()
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
            User = new User();
            LoginCommand = new LoginCommand(this);
        }

        public async void Login()
        {
            bool canLogin = await User.Login(User.Email, User.Password);

            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Try Again", "Ok");
        }
    }
}
