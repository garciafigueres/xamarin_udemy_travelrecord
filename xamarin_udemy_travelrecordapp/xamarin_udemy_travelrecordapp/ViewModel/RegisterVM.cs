using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using xamarin_udemy_travelrecordapp.Model;
using xamarin_udemy_travelrecordapp.ViewModel.Commands;

namespace xamarin_udemy_travelrecordapp.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
    {
        private string email;

        public string Email {
            get { return email; }
            set {
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password {
            get { return password; }
            set {
                password = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword {
            get { return confirmPassword; }
            set {
                confirmPassword = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private Users user;

        public Users User {
            get { return user; }
            set {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterVM()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Register(Users user)
        {
            Users.Register(user);
        }
    }
}
