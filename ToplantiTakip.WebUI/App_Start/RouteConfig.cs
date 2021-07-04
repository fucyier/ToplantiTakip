using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToplantiTakip.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add("Details",
            //    new SeoFriendlyRoute("Post/Detail/{postId}",
            //    new RouteValueDictionary(new { controller = "Post", action = "Detail" }),
            //    new MvcRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ToplantiTakip.WebUI.Controllers" }
            );

        }
    }
}
