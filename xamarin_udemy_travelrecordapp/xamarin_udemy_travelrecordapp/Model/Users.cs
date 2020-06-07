using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xamarin_udemy_travelrecordapp.Model
{
    public class Users : INotifyPropertyChanged
    {
        private string id;

        public string Id {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string email;

        public string Email {
            get { return email; }
            set {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password {
            get { return password; }
            set {
                password = value;
                OnPropertyChanged("Password");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static async Task<bool> Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                var user = (await App.MobileService.GetTable<Users>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;

                    return user.Password == password;
                }
                else
                {
                    return false;
                }
            }
        }

        public static async void Register(Users user)
        {
            await App.MobileService.GetTable<Users>().InsertAsync(user);
        }


    }
}
