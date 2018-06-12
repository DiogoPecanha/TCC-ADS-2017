using System.Web;
using System.Web.Optimization;

namespace TCC.Web {
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.mask.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/metisMenu.js",
                "~/Scripts/site.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/fontawesome*",
                      "~/Content/fa-*",
                      "~/Content/metisMenu.css",
                      "~/Content/site.css"));

            #region Views Admin
            bundles.Add(new ScriptBundle("~/bundles/admin/aluno/cadastro").Include(
                        "~/Scripts/admin/aluno/cadastro.js"));

            #endregion Views Admin
        }
    }
}
