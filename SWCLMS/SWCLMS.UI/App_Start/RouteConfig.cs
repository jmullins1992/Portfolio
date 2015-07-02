using System.Web.Mvc;
using System.Web.Routing;

namespace SWCLMS.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Courses",
                url: "Courses/{id}/{action}/{assignmentId}",
                defaults: new { controller = "Courses", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional}
            );


            //routes.MapRoute(
            //    name: "Admin",
            //    url: "Admin/{action}/{id}",
            //    defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Home",
            //    url: "Home/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Account",
            //    url: "Account/{action}",
            //    defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Index",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);
        }
    }
}
