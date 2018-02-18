using System;
using System.Configuration;
using System.Web.Mvc;

namespace MealRoulette.WebApi.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            var bindingUrl = ConfigurationManager.AppSettings["ApiBindingUrl"];
            if (bindingUrl == null) throw new NullReferenceException("Misconfiguration, Api Binding Url has not be set");

            ViewBag.ApiBindingUrl = ConfigurationManager.AppSettings["ApiBindingUrl"];
        }

        internal void SetPageTitle(string title)
        {
            ViewBag.Title = title;
        }
    }
}