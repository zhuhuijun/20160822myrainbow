using System.Web;
using System.Web.Optimization;

namespace Rainbow.UIs
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/jquery").Include("~/Scripts/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/mian/js").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/plugins/metisMenu/jquery.metisMenu.js",
                        "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js",
                        "~/Scripts/plugins/pace/pace.min.js",
                        "~/Scripts/plugins/layer/layer.min.js",
                        "~/Scripts/hplus.min.js",
                        "~/Scripts/contabs.js"));

            bundles.Add(new StyleBundle("~/main/css").Include(
                      "~/css/bootstrap.min14ed.css",
                      "~/css/font-awesome.min93e3.css",
                      "~/css/animate.min.css",
                      "~/css/style.min862f.css",
                      "~/Scripts/plugins/layer/skin/layer.css",
                      "~/Scripts/plugins/layer/laydate/need/laydate.css",
                      "~/Scripts/plugins/layer/laydate/skins/default/laydate.css",
                      "~/Scripts/plugins/layer/skin/layer.ext.css",
                      "~/Scripts/plugins/layer/skin/moon/style.css"));

            //各个页面需要使用的样式css
            bundles.Add(new StyleBundle("~/bundles/modulescss").Include(
                      "~/css/bootstrap.min14ed.css",
                      "~/css/plugins/jqgrid/ui.jqgridffe4.css",
                      "~/css/font-awesome.min93e3.css",
                      "~/css/animate.min.css",
                      "~/css/style.min862f.css",
                      "~/Scripts/plugins/layer/skin/layer.css",
                      "~/Scripts/plugins/layer/laydate/need/laydate.css",
                      "~/Scripts/plugins/layer/laydate/skins/default/laydate.css",
                      "~/Scripts/plugins/layer/skin/layer.ext.css",
                      "~/Scripts/plugins/layer/skin/moon/style.css",//弹窗提示
                      "~/css/plugins/toastr/toastr.min.css",//消息提示
                      "~/css/plugins/sweetalert/sweetalert.css"//弹窗提示
          ));
            //各个页面使用的js
            bundles.Add(new ScriptBundle("~/bundles/modulejs").Include(
            "~/Scripts/bootstrap.min.js",
            "~/Scripts/plugins/toastr/toastr.min.js",
            "~/Scripts/plugins/jqgrid/jquery.jqGrid.min.js",
            "~/Scripts/plugins/jqgrid/i18n/grid.locale-cnffe4.js",
            "~/Scripts/plugins/peity/jquery.peity.min.js",
            "~/Scripts/plugins/layer/layer.min.js",
            "~/Scripts/plugins/sweetalert/sweetalert-dev.js",//弹窗的js
            "~/Scripts/plugins/validate/jquery.validate.min.js",//表单验证的脚本
            "~/Scripts/plugins/validate/message_zh.min.js",//表单验证的脚本
            "~/Scripts/myjs/commoncrud.js"//
            ));
        }
    }
}
