using System.ComponentModel.DataAnnotations;

namespace Facebook.Presentation.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")] // TODO: Find from resources ...
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}