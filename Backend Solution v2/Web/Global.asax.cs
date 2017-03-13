using System.$safeprojectname$.Http;
using System.$safeprojectname$.Mvc;
using System.$safeprojectname$.Optimization;
using System.$safeprojectname$.Routing;
using $safeprojectname$.App_Start;

namespace $safeprojectname$
{
    public class WebApiApplication : System.$safeprojectname$.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Remove every previously registered view engines
            ViewEngines.Engines.Clear();
            // Registers our Razor C# specific view engine.
            // This can also be registered using dependency injection through the new IDependencyResolver interface.
            ViewEngines.Engines.Add(new RazorViewEngine());

            //Register Autofac
            AutofacConfiguration.ConfigureContainer();
        }
    }
}
