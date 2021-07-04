using ToplantiTakip.Domain.Concrete;
using ToplantiTakip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToplantiTakip.WebUI.Areas.Admin.Models.RoomModels
{
    public class RoomsAdminListViewModel
    {
            public IEnumerable<Room> Rooms { get; set; }
            public PagingInfo PagingInfo { get; set; }      
    }
}