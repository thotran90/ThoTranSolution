using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        // GET: Base
        public LoggedUser CurrentUser => new LoggedUser(User as ClaimsPrincipal);
        protected IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
        /// <summary>
        ///     Helper method that adds the Identity cookie to the request output
        ///     headers. Assigns the userState to the claims for holding user
        ///     data without having to reload the data from disk on each request.
        ///     AppUserState is read in as part of the baseController class.
        /// </summary>
        /// <param name="appUserState"></param>
        /// <param name="providerKey"></param>
        /// <param name="isPersistent"></param>
        public void IdentitySignin(ApplicationState appUserState, string providerKey = null, bool isPersistent = false)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUserState.LoginId),
                new Claim(ClaimTypes.Name, appUserState.UserName),
                new Claim(ClaimTypes.Email, appUserState.Email),
                new Claim(ClaimTypes.PrimarySid, appUserState.UserId.ToString()),
                new Claim("userState", appUserState.ToString())
            };

            // create *required* claims
            // serialized AppUserState object

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            // add to user here!
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);
        }

        public void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}