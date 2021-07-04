using System.Web.Mvc;

namespace ToplantiTakip.WebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                  "Admin_3",
                  "Admin/",
                  new { action = "Index",controller="Event", id = UrlParameter.Optional },
                   namespaces: new[] { "ToplantiTakip.WebUI.Areas.Admin.Controllers" }
              );
            context.MapRoute(
                "Admin_default_2",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "ToplantiTakip.WebUI.Areas.Admin.Controllers" }
            );
        }
    }
}