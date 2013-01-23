using System.Web;

namespace Facebook.Presentation.Web.Security
{
    public class FacebookUserProvider : IUserProvider
    {
        #region Implementation of IUserProvider

        public string GetCurrentUserEmail(HttpContextBase context)
        {
            return "ericjavier@gmail.com"; 

            if (Equals(context, null))
                return string.Empty;

            if (Equals(context.User, null))
                return string.Empty;

            return Equals(context.User.Identity, null) ? string.Empty : context.User.Identity.Name;
        }

        #endregion
    }
}