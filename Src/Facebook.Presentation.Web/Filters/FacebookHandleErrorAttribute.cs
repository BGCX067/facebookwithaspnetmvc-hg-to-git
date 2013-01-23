using System.Text;
using System.Web.Mvc;
using Facebook.Infrastructure.Crosscutting.Logging;

namespace Facebook.Presentation.Web.Filters
{
    public class FacebookHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Logger.Warn(Format(filterContext));
            

            base.OnException(filterContext);
        }

        private static string Format(ExceptionContext filterContext)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Exception: {0}\n", filterContext.Exception.GetType());
            sb.AppendFormat("Exception message: {0}\n", filterContext.Exception.Message);
            sb.AppendFormat("Controller: {0}\n", filterContext.RouteData.Values["controller"]);
            sb.AppendFormat("Action: {0}\n", filterContext.RouteData.Values["action"]);

            return sb.ToString();
        }
    }
}