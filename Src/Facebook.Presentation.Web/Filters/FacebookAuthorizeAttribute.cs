using System;
using System.Web;
using System.Web.Mvc;
using Facebook.Data;
using Facebook.Presentation.Web.Security;
using Facebook.Presentation.Web.Utils;

namespace Facebook.Presentation.Web.Filters
{
    public class FacebookAuthorizeAttribute : AuthorizeAttribute
    {
        public FacebookAuthorizeAttribute()
        {
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userProvider = DependencyResolver.Current.GetService<IUserProvider>();

            if(!userProvider.IsAuthenticate(httpContext))
                return false;

            return true;
        }
    }
}