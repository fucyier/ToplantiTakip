using ToplantiTakip.Business.Abstract;
using ToplantiTakip.Domain.Concrete;
using ToplantiTakip.WebUI.Areas.Admin.Models.TagModels;
using ToplantiTakip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ToplantiTakip.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Admin/Tags
        public ActionResult Index(int page = 1)
        {
            var departments = _departmentService.GetAll();

            var departmentModel = new DepartmentsAdminListViewModel()
            {
                Departments = departments.Skip((page - 1) * 10).Take(10),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = 10,
                    TotalItems = departments.Count(),
                    TotalPageCount = (int)Math.Ceiling((decimal)departments.Count() / 10),
                },

            };
            return View(departmentModel);
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.Get(id.Value);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Admin/Tags/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Authors/Create

      
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                
                _departmentService.Add(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Admin/Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.Get(id.Value);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Admin/Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
               
                _departmentService.Update(department);

                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Admin/Tag/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.Get(id.Value);

            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Department department)
        {


            if (department == null)
            {
                return HttpNotFound();
            }

            try
            {
                _departmentService.Delete(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Bağlantılı kayıtlar olduğundan silemezsiniz");
                return View(department);
            }

        }
    }
}