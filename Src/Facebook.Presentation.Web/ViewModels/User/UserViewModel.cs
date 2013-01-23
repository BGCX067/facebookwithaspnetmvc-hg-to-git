using System.Web.Mvc;
using Facebook.Business.Domain;

namespace Facebook.Presentation.Web.ViewModels.User
{
    public class UserViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string FacebookId { get; set; }

        
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public FriendshipStatus FriendshipStatus { get; set; }


        public ImageViewModel Photo { get; set; }
    }
}