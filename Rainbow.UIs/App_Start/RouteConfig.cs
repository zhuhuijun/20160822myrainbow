using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rainbow.UIs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "LoginManager", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            "Login", // 路由名称
            "{controller}/{action}", // 带有参数的 URL
                new { controller = "LoginManager", action = "Login" } // 参数默认值
            );
        }
    }
}
