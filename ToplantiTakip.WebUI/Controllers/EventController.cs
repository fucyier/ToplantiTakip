using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.WebUI.Models;

namespace ToplantiTakip.WebUI.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private IEventService _evetService;
        private IDepartmentService _departmentService;
        private IRoomService _roomService;
        public EventController(IEventService eventService, IDepartmentService departmentService, IRoomService roomService)
        {
            _evetService = eventService;
            _departmentService = departmentService;
            _roomService = roomService;
        }
        // GET: Event
        public ActionResult Index(int page=1)
        {
            var events = _evetService.GetAll();

            var eventModel = new EventsListViewModel()
            {
                Events = events.Where(x=>x.UserId== User.Identity.GetUserId()).Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = events.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)events.Count() / 10),
                },

            };
            return View(eventModel);
        }
    }
}