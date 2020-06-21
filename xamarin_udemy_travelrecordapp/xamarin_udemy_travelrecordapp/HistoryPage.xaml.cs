using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_udemy_travelrecordapp.Model;
using xamarin_udemy_travelrecordapp.ViewModel;

namespace xamarin_udemy_travelrecordapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        HistoryVM viewModel;
        public HistoryPage()
        {
            InitializeComponent();

            viewModel = new HistoryVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }

        private void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            var post = (Post)((MenuItem)sender).CommandParameter;
            viewModel.DeletePost(post);

            viewModel.UpdatePosts();
        }

        private async void postListView_Refreshing(object sender, System.EventArgs e)
        {
            await viewModel.UpdatePosts();
            postListView.IsRefreshing = false;
        }
    }
}