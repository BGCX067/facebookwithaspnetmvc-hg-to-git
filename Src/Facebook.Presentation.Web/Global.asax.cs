using System.Data.Entity;
using Facebook.Data.EntityFramework;
using Facebook.Presentation.Web.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Facebook.Presentation.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Database.SetInitializer(new DropCreateDatabaseAlways<FacebookContext>());
            DependencyConfig.Register();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            AutoMapperConfig.Configure();
        }
    }
}