using System;
using System.Web.Mvc;

namespace Facebook.Presentation.Web.Filters
{
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                throw new Exception();
        }   
    }
}