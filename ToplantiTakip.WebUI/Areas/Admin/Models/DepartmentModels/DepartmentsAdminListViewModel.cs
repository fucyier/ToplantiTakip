using ToplantiTakip.Domain.Concrete;
using ToplantiTakip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToplantiTakip.WebUI.Areas.Admin.Models.TagModels
{
    public class DepartmentsAdminListViewModel
    {
            public IEnumerable<Department> Departments { get; set; }
            public PagingInfo PagingInfo { get; set; }
    }
}