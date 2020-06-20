using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using xamarin_udemy_travelrecordapp.Model;

namespace xamarin_udemy_travelrecordapp.ViewModel
{
    public class HistoryVM
    {
        public ObservableCollection<Post> Posts { get; set; }

        public HistoryVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async void UpdatePosts()
        {
            var posts = await Post.Read();

            if (posts != null)
            {
                Posts.Clear();
                foreach (var post in posts)
                    Posts.Add(post);
            }
        }
    }
}
