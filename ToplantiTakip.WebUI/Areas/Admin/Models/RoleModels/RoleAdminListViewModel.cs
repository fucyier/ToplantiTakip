using ToplantiTakip.Domain.Concrete;
using ToplantiTakip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToplantiTakip.WebUI.Areas.Admin.Models.RoleModels
{
    public class RoleAdminListViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}