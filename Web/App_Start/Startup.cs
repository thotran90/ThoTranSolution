using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Configuration;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(Web.App_Start.Startup))]
namespace Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            var cookieName = ConfigurationManager.AppSettings["ApplicationName"].ToString();

            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/Login"),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                SlidingExpiration = false,
                ExpireTimeSpan = TimeSpan.FromHours(24),
                CookieName = cookieName
            };
            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);
            app.UseCookieAuthentication(cookieOptions);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}