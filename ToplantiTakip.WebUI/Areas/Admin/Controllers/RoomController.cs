using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToplantiTakip.Domain.Concrete;
using ToplantiTakip.WebUI.Models;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.WebUI.Areas.Admin.Models;
using ToplantiTakip.WebUI.Areas.Admin.Models.RoomModels;

namespace ToplantiTakip.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        private IDepartmentService _departmentService;
        public RoomController(IRoomService roomService,IDepartmentService departmentService)
        {
            _roomService = roomService;
            _departmentService = departmentService;
        }

        // GET: Admin/Authors
        public ActionResult Index(int page = 1)
        {
            var rooms = _roomService.GetAll();

            var roomModel = new RoomsAdminListViewModel()
            {
                Rooms = rooms.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = rooms.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)rooms.Count() / 10),
                },

            };
            return View(roomModel);
        }

        // GET: Admin/Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = _roomService.Get(id.Value);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Admin/Authors/Create
        public ActionResult Create()
        {
            var room = _roomService.GetNewObject();
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "DepartmentId", "DepartmentName");
            return View(room);
        }

        // POST: Admin/Authors/Create

      
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    room.ImageType = image.ContentType;
                    room.RoomImage = new byte[image.ContentLength];
                    image.InputStream.Read(room.RoomImage, 0, image.ContentLength);
                }
                _roomService.Add(room);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "DepartmentId", "DepartmentName",room.DepartmentId);
            return View(room);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = _roomService.Get(id.Value);
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "DepartmentId", "DepartmentName",room.DepartmentId);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Admin/Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    room.ImageType = image.ContentType;
                    room.RoomImage = new byte[image.ContentLength];
                    image.InputStream.Read(room.RoomImage, 0, image.ContentLength);
                }
                _roomService.Update(room);

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_departmentService.GetAll(), "DepartmentId", "DepartmentName", room.DepartmentId);
            return View(room);
        }

        // GET: Admin/Authors/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = _roomService.Get(id.Value);

            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
           

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Room room)
        {
           

            if (room == null)
            {
                return HttpNotFound();
            }
           
            try
            {
                _roomService.Delete(room);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bağlantılı post lar olduğundan silemezsiniz");
                return View(room);
            }

        }

        public FileContentResult GetImage(int roomId)
        {
            Room room = _roomService.Get(roomId);

            if (room != null)
            {
                if (room.RoomImage != null && room.ImageType != null)
                {
                    return File(room.RoomImage, room.ImageType);
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
    }
}
