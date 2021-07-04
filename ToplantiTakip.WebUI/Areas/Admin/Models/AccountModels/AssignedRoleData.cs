using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToplantiTakip.WebUI.Areas.Admin.Models.AccountModels
{
    public class AssignedRoleData
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Assigned { get; set; }
    }
}