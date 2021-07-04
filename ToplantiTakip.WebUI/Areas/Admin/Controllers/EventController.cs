using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ToplantiTakip.Business.Abstract;
using ToplantiTakip.Domain.Concrete;
using ToplantiTakip.WebUI.Areas.Admin.Models.EventModels;
using ToplantiTakip.WebUI.Models;
using static ToplantiTakip.Core.Utilities.Enums;

namespace ToplantiTakip.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private IEventService _evetService;
        private IDepartmentService _departmentService;
        private IRoomService _roomService;
        private IEventDocumentService _eventDocumentService;
        public EventController(IEventService eventService, IDepartmentService departmentService, IRoomService roomService, IEventDocumentService eventDocumentService)
        {
            _evetService = eventService;
            _departmentService = departmentService;
            _roomService = roomService;
            _eventDocumentService = eventDocumentService;
        }

        public ActionResult Index(int page = 1)
        {
            var events = _evetService.GetAll().OrderByDescending(x=>x.ReservationDate);

            var eventModel = new EventsAdminListViewModel()
            {
                Events = events.Skip((page - 1) * 10).Take(10),
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
        public ActionResult Create()
        {
            var _event = _evetService.GetNewObject();

            ViewBag.RoomId = new SelectList(_roomService.GetAll(), "RoomId", "RoomName");
            return View(_event);
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event)
        {

            if (ModelState.IsValid)
            {

                List<EventDocument> files = new List<EventDocument>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        EventDocument document = new EventDocument()
                        {
                            Document = new byte[file.ContentLength],
                            DocumentType = Path.GetExtension(fileName),
                            DocumentName = fileName

                        };
                        files.Add(document);

                        // var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                        //  file.SaveAs(path);
                    }
                }
                @event.Status = EventStatus.Bekliyor;
                @event.ThemeColor = "orange";
                @event.EventDocument = files;
                @event.ReservationDate = DateTime.Now;
                @event.ApproveDate = null;
                @event.UserId = User.Identity.GetUserId();
                _evetService.Add(@event);
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(_roomService.GetAll(), "RoomId", "RoomName", @event.RoomId);
            return View(@event);
        }
        //private void PopulateAssignedPostTag(Post post)
        //{
        //    var allTags = _tagService.GetAll();
        //    var postTags = new HashSet<int>(post.Tags.Select(c => c.TagId));
        //    var assignedTagData = new List<AssignedTagData>();
        //    foreach (var tag in allTags)
        //    {
        //        assignedTagData.Add(new AssignedTagData
        //        {
        //            TagID = tag.TagId,
        //            TagName = tag.TagText,
        //            Assigned = postTags.Contains(tag.TagId)
        //        });
        //    }
        //    ViewBag.Tags = assignedTagData;
        //}

        public ActionResult Edit(int id)
        {
            var _event = _evetService.Get(id);
            ViewBag.RoomId = new SelectList(_roomService.GetAll(), "RoomId", "RoomName", _event.RoomId);
            return View(_event);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event _event)
        {

            if (ModelState.IsValid)
            {
                //if (image != null)
                //{
                //    //_event.DocumentType = image.ContentType;
                //    //_event.EventDocument = new byte[image.ContentLength];
                //    //image.InputStream.Read(_event.EventDocument, 0, image.ContentLength);
                //    EventDocument e = new EventDocument()
                //    {
                //        EventDocumentId = _event.EventId,
                //        Document = new byte[image.ContentLength],
                //        DocumentType = image.ContentType
                //    };
                //    image.InputStream.Read(e.Document, 0, image.ContentLength);
                //    _event.EventDocument.Add(e);
                //}
                List<EventDocument> files = new List<EventDocument>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        EventDocument document = new EventDocument()
                        {
                            Document = new byte[file.ContentLength],
                            DocumentType = Path.GetExtension(fileName),
                            DocumentName = fileName,
                            EventId = _event.EventId

                        };
                        files.Add(document);

                        // var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                        //  file.SaveAs(path);
                        _event.EventDocument = files;
                    }
                }

                if (_event.Status == EventStatus.Onaylandı)
                {
                    _event.ThemeColor = "green";
                    _event.ApproveDate = DateTime.Now;
                    _event.ApproveUserId = User.Identity.GetUserId();
                }
                else if (_event.Status == EventStatus.Bekliyor)
                {
                    _event.ThemeColor = "orange";
                }
                else if (_event.Status == EventStatus.Reddedildi)
                {
                    _event.ThemeColor = "red";
                }

                _evetService.Update(_event);
                return RedirectToAction("Index");
            }
            //  PopulateAssignedPostTag(post);
            ViewBag.RoomId = new SelectList(_roomService.GetAll(), "RoomId", "RoomName", _event.RoomId);
            return View(_event);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event _event = _evetService.Get(id.Value);

            if (_event == null)
            {
                return HttpNotFound();
            }
            return View(_event);


        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Event _event)
        {


            if (_event == null)
            {
                return HttpNotFound();
            }

            try
            {
                _evetService.Delete(_event);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bağlantılı entity ler olduğundan silemezsiniz");
                return View(_event);
            }

        }
        // GET: Admin/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event _event = _evetService.Get(id.Value);
            if (_event == null)
            {
                return HttpNotFound();
            }
            return View(_event);
        }
        public List<FileContentResult> GetImage(int eventId)
        {
            Event _event = _evetService.Get(eventId);

            if (_event != null)
            {
                List<FileContentResult> files = new List<FileContentResult>();

                if (_event.EventDocument != null && _event.EventDocument.Count > 0)
                {
                    foreach (EventDocument item in _event.EventDocument)
                    {
                        files.Add(File(item.Document, item.DocumentType));
                    }

                    return files;
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
        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {

                EventDocument fileDetail = _eventDocumentService.Get(Convert.ToInt32(id));
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                _eventDocumentService.Delete(fileDetail);


                //Delete file from the file system
                //  var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                //if (System.IO.File.Exists(path))
                //{
                //    System.IO.File.Delete(path);
                //}
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}