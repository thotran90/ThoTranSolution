using System.$safeprojectname$.Mvc;
using $safeprojectname$.Services.Contracts;

namespace $safeprojectname$.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApplicationService _applicationService;

        public HomeController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public ActionResult Index()
        {
            var app = _applicationService.GetApp();
            ViewBag.Title = "Home Page "+app?.Description;

            return View();
        }
    }
}
