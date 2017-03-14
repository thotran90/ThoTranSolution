using System.Web.Mvc;
using $safeprojectname$.Arguments;
using $safeprojectname$.ViewModels;
using $safeprojectname$;

using Web.Models;

namespace Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly $safeprojectname$.IUserService _userService;
        public AccountController($safeprojectname$.IUserService userService)
        {
            this._userService = userService;
        }

        #region Anonymous

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var arg = new LoginArgument()
                {
                    LoginId = model.LoginId,
                    Password = model.Password
                };

                var result = _userService.LoginByPassword(arg);

                if (result != null && result.UserId != 0)
                {
                    IdentitySignin(new ApplicationState()
                    {
                        UserId = result.UserId,
                        LoginId = result.LoginId,
                        Email = result.Email,
                        UserName = result.UserName
                    });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("invalid", message.LoginFaileMessage);
                    return View();
                }

            }
            ModelState.AddModelError("invalid", message.FormInvalidMessage);
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignOut()
        {
            IdentitySignout();
            return RedirectToAction("Login");
        }
        #endregion
    }
}