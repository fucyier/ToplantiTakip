using ToplantiTakip.Domain.Concrete;
using ToplantiTakip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToplantiTakip.WebUI.Areas.Admin.Models.AccountModels
{
    public class AccountsAdminListViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}