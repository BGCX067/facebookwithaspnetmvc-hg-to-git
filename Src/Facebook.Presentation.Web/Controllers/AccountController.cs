using System.Web.Mvc;
using Facebook.Infrastructure.Contracts;
using Facebook.Presentation.Web.Filters;
using Facebook.Presentation.Web.Security;
using Facebook.Presentation.Web.ViewModels.Account;

namespace Facebook.Presentation.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserProvider _userProvider;
        private readonly IMembershipProvider _membershipProvider;
        private readonly IWebSecurity _webSecurity;

        public AccountController(IMembershipProvider membershipProvider, IUserProvider userProvider, IWebSecurity webSecurity)
        {
            ContractUtil.NotNull(membershipProvider);
            ContractUtil.NotNull(userProvider);
            ContractUtil.NotNull(webSecurity);

            _userProvider = userProvider;
            _membershipProvider = membershipProvider;
            _webSecurity = webSecurity;
        }

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            if (!Equals(_userProvider.GetCurrentUserEmail(HttpContext), string.Empty))
                return RedirectToAction("Home", "User");

            return View();
        }

        [FacebookAuthorize]
        public ActionResult LogOff()
        {
            _webSecurity.Logout();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid && _membershipProvider.Validate(viewModel.Email, viewModel.Password))
            {
                _webSecurity.Login(viewModel.Email);
                return RedirectToAction("Home", "User");
            }

            ModelState.AddModelError(string.Empty, Resources.Strings.LoginError);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid && _membershipProvider.Register(viewModel.FirstName, 
                                                                   viewModel.LastName,
                                                                   viewModel.Email,
                                                                   viewModel.Password, 
                                                                   viewModel.SecurityQuestion, 
                                                                   viewModel.SecurityAnswer))
            {
                _webSecurity.Login(viewModel.Email);
                return RedirectToAction("Home", "User");
            }

            ModelState.AddModelError(string.Empty, Resources.Strings.RegisterError);
            return View(viewModel);
        }
    }
}
