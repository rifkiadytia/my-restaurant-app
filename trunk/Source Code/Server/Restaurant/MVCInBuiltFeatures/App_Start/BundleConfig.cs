using System.Web;
using System.Web.Optimization;

namespace MVCInBuiltFeatures
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            //assign role script bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery-assign-role").Include(
                        "~/Scripts/rolejs/*.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/jquery-ui/css").Include(
                        "~/Content/jquery-ui/jquery-ui.css"

                        ));
            //End
            //Admin script
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery-admin").Include(
                        "~/Scripts/cpanel/jquery-1.9.1.min.js"
                        ,"~/Scripts/cpanel/jquery-migrate-1.1.1.min.js"));
            //jquery-ui
             bundles.Add(new ScriptBundle("~/bundles/jquery-admin-ui").Include(
                        "~/Scripts/cpanel/jquery-ui-1.9.2.min.js"));
            //bootrap
            bundles.Add(new ScriptBundle("~/bundles/jquery-response").Include(
                        "~/Scripts/cpanel/modernizr.min.js"
                        ,"~/Scripts/cpanel/bootstrap.min.js"));
            //cookies
            bundles.Add(new ScriptBundle("~/bundles/jquery-cookies").Include(
                        "~/Scripts/cpanel/jquery.cookie.js"));
            //custom
            bundles.Add(new ScriptBundle("~/bundles/jquery-custom").Include(
                        "~/Scripts/cpanel/custom.js"));
            //uniform
            bundles.Add(new ScriptBundle("~/bundles/jquery-uniform").Include(
                        "~/Scripts/cpanel/jquery.uniform.min.js"
                        ,"~/Scripts/cpanel/flot/jquery.flot.min.js"
                        ,"~/Scripts/cpanel/flot/jquery.flot.resize.min.js"
                        ,"~/Scripts/cpanel/responsive-tables.js"));
            //excanvas
            bundles.Add(new ScriptBundle("~/bundles/jquery-excanvas").Include(
                        "~/Scripts/cpanel/excanvas.min.js"));
            //End admin template script
            //Admin css
            bundles.Add(new StyleBundle("~/Content/admin-css").Include(
                      "~/Content/cpanel/css/style.default.css",
                      "~/Content/cpanel/css/style.shinyblue.css"));
            bundles.Add(new StyleBundle("~/Content/admin-table-css").Include(
                      "~/Content/cpanel/css/responsive-tables.css"));
            
            //End admin css
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery.ui.dialog.css"));
        }
    }
}
