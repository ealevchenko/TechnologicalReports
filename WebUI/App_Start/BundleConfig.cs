using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Добавил
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui.min.js"));

            bundles.Add(new StyleBundle("~/jquery-ui/css").Include(
                      "~/Content/jquery-ui/jquery-ui.css",
                      "~/Content/jquery-ui/jquery-ui.structure.css",
                      "~/Content/jquery-ui/jquery-ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/easing").Include(
                        "~/Scripts/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/iconmenu").Include(
                        "~/Scripts/jquery.iconmenu.js"));

            bundles.Add(new StyleBundle("~/Home/css").Include(
                      "~/Content/home/reset.css",
                      "~/Content/home/stimenu.css",
                      "~/Content/home/style.css"));

            bundles.Add(new StyleBundle("~/Layout-report/css").Include(
                      "~/Content/layout-report/reset.css",
                      "~/Content/layout-report/layout-report.css",
                      "~/Content/layout-report/style.css"));

            bundles.Add(new StyleBundle("~/datetime/css").Include("~/Content/datetime/daterangepicker.css"));
            bundles.Add(new ScriptBundle("~/bundles/datetime")
                .Include(
                 "~/Scripts/datetime/moment.min.js"
                , "~/Scripts/datetime/jquery.daterangepicker.js"
                , "~/Scripts/helpers/lib-datetime.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Ajax").Include(
            "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Плагин таблицы
            bundles.Add(new StyleBundle("~/table/css").Include("~/Content/table/jquery.dataTables.min.css",
                "~/Content/table/jquery-ui.css"));
            bundles.Add(new ScriptBundle("~/bundles/table")
                .Include(
                 "~/Scripts/table/jquery.dataTables.min.js",
                 "~/Scripts/table/dataTables.jqueryui.min.js"
                ));
        }
    }
}
