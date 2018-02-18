using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MealRoulette.WebApi.Controllers
{
    public class MealRouletteController : BaseController
    {
        // GET: MealRoulette
        public ActionResult Index()
        {
            return View();
        }
    }
}