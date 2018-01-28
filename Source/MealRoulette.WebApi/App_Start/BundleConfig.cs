using System.Web.Optimization;

namespace MealRoulette.WebApi
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Content/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/content/js/jquery").Include(
                "~/Content/js/jquery-3.2.1.js"));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                "~/Content/js/materialize.js",
                "~/Content/js/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/materialize.css",
                "~/Content/css/site.css"));
        }
    }
}
