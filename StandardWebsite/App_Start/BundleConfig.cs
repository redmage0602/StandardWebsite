using System.Web.Optimization;

namespace StandardWebsite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

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
                "~/Content/site.css"));
            
            bundles.Add(new StyleBundle("~/Content/FlatPointCSS").Include(
                  "~/Content/FlatPoint/css/bootstrap-responsive.css"
                , "~/Content/FlatPoint/css/bootstrap.css"
                , "~/Content/FlatPoint/css/stylesheet.css"
                , "~/Content/FlatPoint/icon/font-awesome.css"
                , "~/Content/Custom.css"
            ));

            bundles.Add(new ScriptBundle("~/Content/FlatPointJS").Include(
                  "~/Content/FlatPoint/js/jquery-1.10.2.js"
                , "~/Content/FlatPoint/js/jquery-ui-1.10.3.js"
                , "~/Content/FlatPoint/js/bootstrap.js"

                , "~/Content/FlatPoint/js/library/jquery.collapsible.min.js"
                , "~/Content/FlatPoint/js/library/jquery.mCustomScrollbar.min.js"
                , "~/Content/FlatPoint/js/library/jquery.mousewheel.min.js"
                , "~/Content/FlatPoint/js/library/jquery.uniform.min.js"

                , "~/Content/FlatPoint/js/library/jquery.sparkline.min.js"
                , "~/Content/FlatPoint/js/library/chosen.jquery.min.js"
                , "~/Content/FlatPoint/js/library/jquery.easytabs.js"

                , "~/Content/FlatPoint/js/library/flot/excanvas.min.js"
                , "~/Content/FlatPoint/js/library/flot/jquery.flot.js"
                , "~/Content/FlatPoint/js/library/flot/jquery.flot.pie.js"
                , "~/Content/FlatPoint/js/library/flot/jquery.flot.selection.js"
                , "~/Content/FlatPoint/js/library/flot/jquery.flot.resize.js"
                , "~/Content/FlatPoint/js/library/flot/jquery.flot.orderBars.js"

                , "~/Content/FlatPoint/js/library/maps/jquery.vmap.js"
                , "~/Content/FlatPoint/js/library/maps/maps/jquery.vmap.world.js"
                , "~/Content/FlatPoint/js/library/maps/data/jquery.vmap.sampledata.js"

                , "~/Content/FlatPoint/js/library/jquery.autosize-min.js"
                , "~/Content/FlatPoint/js/library/charCount.js"
                , "~/Content/FlatPoint/js/library/jquery.minicolors.js"
                , "~/Content/FlatPoint/js/library/jquery.tagsinput.js"
                , "~/Content/FlatPoint/js/library/fullcalendar.min.js"

                , "~/Content/FlatPoint/js/library/footable/footable.js"
                , "~/Content/FlatPoint/js/library/footable/data-generator.js"

                , "~/Content/FlatPoint/js/library/bootstrap-datetimepicker.js"
                , "~/Content/FlatPoint/js/library/bootstrap-timepicker.js"
                , "~/Content/FlatPoint/js/library/bootstrap-datepicker.js"
                , "~/Content/FlatPoint/js/library/bootstrap-fileupload.js"
                , "~/Content/FlatPoint/js/library/jquery.inputmask.bundle.js"
            ));
        }
    }
}