using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Security.Principal;
using System.Web;

namespace ToplantiTakip.WebUI.Infrastructure
{
    public static class IdentityExtensions
    {
        public static string GetFullName(this IIdentity identity)
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userDetails = userManager.FindByIdAsync(currentUserId).Result;
            return String.Format("{0} {1}", userDetails.FirstName, userDetails.LastName);
        }
    }
}