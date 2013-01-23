using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Presentation.Web.Security;
using Facebook.Presentation.Web.ViewModels.User;

namespace Facebook.Presentation.Web.Utils
{
    public static class Extensions
    {
        public static User GetCurrentUser(this IUserProvider userProvider, IUnitOfWork unitOfWork, HttpContextBase context)
        {
            var email = userProvider.GetCurrentUserEmail(context);

            return Equals(email, string.Empty) ? null : unitOfWork.Users.FindByEmail(email);
        }

        public static bool IsAuthenticate(this IUserProvider userProvider, HttpContextBase context)
        {
            var email = userProvider.GetCurrentUserEmail(context);
            return !Equals(email, null) && !Equals(email, string.Empty);
        }

        public static bool IsJsonRequest(this HttpRequestBase request)
        {
            return string.Equals(request["format"], "json");
        }

        public static MvcHtmlString UserName(this HtmlHelper helper, UserViewModel user)
        {
            return helper.ActionLink(actionName: "Index", 
                                     controllerName: "User", 
                                     htmlAttributes: new { @class = "user-name" },
                                     routeValues: new { keyword = user.FacebookId }, 
                                     linkText: user.Name);
        }
    }
}
