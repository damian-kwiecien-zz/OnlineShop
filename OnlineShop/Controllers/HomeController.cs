using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult He()
        {
            ViewBag.Title = "Test Page";

            return View();
        }

        public ActionResult She()
        {
            ViewBag.Title = "Test Page";

            return View();
        }
    }
}
