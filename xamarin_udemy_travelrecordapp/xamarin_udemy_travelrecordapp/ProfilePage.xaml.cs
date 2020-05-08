using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_udemy_travelrecordapp.Model;
using System.Linq;

namespace xamarin_udemy_travelrecordapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                var categories = (from p in postTable
                                  orderby p.CategoryId
                                  select p.CategoryName).Distinct().ToList();

                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}