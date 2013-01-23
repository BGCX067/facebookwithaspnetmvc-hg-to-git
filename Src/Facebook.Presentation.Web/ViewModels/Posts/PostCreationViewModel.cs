using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Facebook.Presentation.Web.ViewModels.Posts
{
    public class PostCreationViewModel
    {
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int OwnerId { get; set; }
    }
}