using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.Domain.Concrete;
using static ToplantiTakip.Core.Utilities.Enums;

namespace ToplantiTakip.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IEventService eventService;
        private IRoomService roomService;
        //public UserManager<ApplicationUser> UserManager { get; private set; }

        //public HomeController(): this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ToplantiTakipContext())))
        //{

        //}
        //public HomeController(UserManager<ApplicationUser> userManager)
        //{
        //    UserManager = userManager;
        //}
        public HomeController(IEventService _eventService, IRoomService _roomService)
        {
            eventService = _eventService;
            roomService = _roomService;
        }
        public ActionResult Index()
        {
            ViewBag.RoomId = new SelectList(roomService.GetAll(), "RoomId", "RoomName");
            return View();
        }
        public JsonResult GetEvents(int? roomId)
        {
            var events = eventService.GetByRoomId(roomId).Where(e => e.Status != EventStatus.Reddedildi);
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;

            string userId = User?.Identity?.GetUserId();
            if (e.EventId > 0)
            {
                var v = eventService.Get(e.EventId);
                if (v != null)
                {
                    if (v.Status != EventStatus.Onaylandı)
                    {
                        if (!string.IsNullOrEmpty(userId))
                        {
                            if (userId != v.UserId)
                            {
                                return new JsonResult { Data = new { status = false, message = "Bu kaydı güncellemeye yetkiniz yoktur!" } };
                            }
                            e.UserId = userId;
                        }
                        if (e.IsFullDay == true)
                        {
                            e.EndDate = e.StartDate.Date + new TimeSpan(18, 00, 00);
                        }
                        e.ReservationDate = DateTime.Now;
                        eventService.Update(e);

                    }
                    else
                    {
                        return new JsonResult { Data = new { status = false, message = "Onaylanan kaydı güncelleyemezsiniz!" } };
                    }

                }
            }
            else
            {
                e.ReservationDate = DateTime.Now;
                e.ApproveDate = null;
                e.Status = EventStatus.Bekliyor;
                if (!string.IsNullOrEmpty(userId))
                {
                    e.UserId = userId;
                }
                if (e.IsFullDay == true)
                {
                    e.EndDate = e.StartDate.Date + new TimeSpan(18, 00, 00);
                }
                eventService.Add(e);
            }

            status = true;

            return new JsonResult { Data = new { status = status } };
        }
        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            string userId = User?.Identity?.GetUserId();
            var v = eventService.Get(eventID);
            if (v != null)
            {
                if (v.Status != EventStatus.Onaylandı)
                {
                    if (!string.IsNullOrEmpty(userId))
                    {
                        if (userId != v.UserId)
                        {
                            return new JsonResult { Data = new { status = false, message = "Bu kaydı güncellemeye yetkiniz yoktur!" } };
                        }

                        eventService.Delete(v);
                        status = true;
                        return new JsonResult { Data = new { status = status } };
                    }
                    else
                    {
                        return new JsonResult { Data = new { status = false, message = "Kullanıcı bulunamadı" } };
                    }

                }
                else
                {
                    return new JsonResult { Data = new { status = false, message = "Onaylanan kaydı silemezsiniz" } };
                }
            }
            else
            {
                return new JsonResult { Data = new { status = false, message = "Kayıt bulunamadı" } };
            }
        }
    }
}