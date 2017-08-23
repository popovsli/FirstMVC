using System.Web;
using System.Web.Optimization;

namespace FirstMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryValidation")
               .Include("~/Scripts/jquery-{version}.js")
               .Include("~/Scripts/jquery.validate.js")
               .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
               .Include("~/Scripts/jquery.validate.unobtrusive.js")
               .Include("~/Scripts/jquery-{version}.min.js")
               .Include("~/Scripts/jquery-ui-{version}.min.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/test")
                .Include("~/Content/themes/base/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css","~/Content/site.css"));

        }
    }
}
