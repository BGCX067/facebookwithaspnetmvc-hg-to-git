using Facebook.Presentation.Web.ViewModels.User;

namespace Facebook.Presentation.Web.ViewModels
{
    public class CommentViewModel
    {
        public string Text { get; set; }

        public UserViewModel Author { get; set; }
    }
}