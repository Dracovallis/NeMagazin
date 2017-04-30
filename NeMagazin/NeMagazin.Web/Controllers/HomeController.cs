using System.Web.Mvc;
using NeMagazin.Models.ViewModels.Home;
using NeMagazin.Services;

namespace NeMagazin.Web.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderUserName()
        {
            string username = User.Identity.Name;
            NavbarUserVM vm = this.service.GetNavBarUserVM(username);

            return PartialView("_RenderUserName",vm);
        }
    }
}