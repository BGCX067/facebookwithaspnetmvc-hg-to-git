using Facebook.Presentation.Web.ViewModels.User;

namespace Facebook.Presentation.Web.ViewModels.Messages
{
    public class MessageViewModel
    {
        public UserViewModel Sender { get; set; }

        public string Text { get; set; }
    }
}