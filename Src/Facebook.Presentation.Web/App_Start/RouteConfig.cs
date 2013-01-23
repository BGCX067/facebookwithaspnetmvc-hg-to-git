using System.Web.Mvc;
using System.Web.Routing;

namespace Facebook.Presentation.Web.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*
             *      routes design:
             *      
             *      - domain                                => give the own wall, with our posts and so on ...
             *      - domain\userIdentifier                 => give the wall of the user that userIdentifier represent ...
             *      - domain\welcome                        => give the opportinity to register as a new user or just login
             *      
             * 
             * 
             * 
             */


            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "Welcome",
               url: "welcome",
               defaults: new { controller = "Account", action = "Index" });


            routes.MapRoute(
                name: "Friends",
                url: "{keyword}",
                defaults: new {controller = "User", action = "Index", id = UrlParameter.Optional} //,
                /* constraints: new {keyword = "\\w+"} */);
                //TODO: Improve the constrain expresion to match expectations.

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "User", action = "Home", id = UrlParameter.Optional});

        }
    }
}