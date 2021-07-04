using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.WebUI.Models
{
    public class EventsListViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}