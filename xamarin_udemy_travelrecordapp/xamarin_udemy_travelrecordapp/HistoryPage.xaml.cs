using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_udemy_travelrecordapp.Model;

namespace xamarin_udemy_travelrecordapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var posts = await Post.Read();
            postListView.ItemsSource = posts;
        }
    }
}