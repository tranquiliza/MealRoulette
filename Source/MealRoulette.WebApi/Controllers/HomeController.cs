using System.Web.Mvc;

namespace MealRoulette.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public ActionResult Meals()
        {
            ViewBag.Title = "Meals";
            return View();
        }
    }
}
