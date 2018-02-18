using System.Web.Mvc;

namespace MealRoulette.WebApi.Controllers
{
    public class MealController : BaseController
    {
        // GET: Meal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}