using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_udemy_travelrecordapp.Model;
using xamarin_udemy_travelrecordapp.ViewModel;

namespace xamarin_udemy_travelrecordapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        RegisterVM viewModel;

        public RegisterPage()
        {
            InitializeComponent();
            viewModel = new RegisterVM();
            BindingContext = viewModel;
        }        
    }
}