using System.Web.Mvc;

namespace MealRoulette.WebApi.Controllers
{
    public abstract class BaseController : Controller
    {
        internal void SetPageTitle(string title)
        {
            ViewBag.Title = title;
        }
    }
}