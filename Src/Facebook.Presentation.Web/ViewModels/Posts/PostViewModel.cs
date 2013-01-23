using System.Collections.Generic;
using System.Web.Mvc;
using Facebook.Presentation.Web.ViewModels.User;

namespace Facebook.Presentation.Web.ViewModels.Posts
{
    public class PostViewModel
    {
        public string Text { get; set; }

        public UserViewModel Author { get; set; }

        public int OwnerId { get; set; }

        public CommentCollectionViewModel Comments { get; set; } 
    }
}