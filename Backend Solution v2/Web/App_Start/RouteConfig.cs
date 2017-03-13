using System;
using System.Collections.Generic;
using System.Linq;
using System.$safeprojectname$;
using System.$safeprojectname$.Mvc;
using System.$safeprojectname$.Routing;

namespace $safeprojectname$
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
