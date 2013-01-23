using System.Web.Mvc;
using Facebook.Presentation.Web.Filters;

namespace Facebook.Presentation.Web.App_Start
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new FacebookHandleErrorAttribute());
        }
    }
}