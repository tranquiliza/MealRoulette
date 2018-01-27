using System.Web.Mvc;

namespace MealRoulette.WebApi.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            SetPageTitle("Home Page");

            return View();
        }

        public ActionResult Contact()
        {
            SetPageTitle("Contact");

            return View();
        }
    }
}
