using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineSmartPhoneShop_DbContext;
using OnlineSmartPhoneShop_Entities.Models;
using PagedList;

namespace OnlineSmartphonesShop.Controllers
{
    public class SmartphonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Smartphones
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {

                page = 1;
            }
            else
            {
                searchString = currentFilter;

            }

            ViewBag.CurrentFilter = searchString;

            var smartphones = from s in db.Smartphones select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                smartphones = smartphones.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    smartphones = smartphones.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    smartphones = smartphones.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    smartphones = smartphones.OrderByDescending(s => s.ReleaseDate);
                    break;
                default:
                    smartphones = smartphones.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(smartphones.ToPagedList(pageNumber, pageSize));
        }

        // GET: Smartphones/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // GET: Smartphones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smartphones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,ImgURL,Description,ReleaseDate")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Smartphones.Add(smartphone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smartphone);
        }

        // GET: Smartphones/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // POST: Smartphones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,ImgURL,Description,ReleaseDate")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smartphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smartphone);
        }

        // GET: Smartphones/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // POST: Smartphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Smartphone smartphone = db.Smartphones.Find(id);
            db.Smartphones.Remove(smartphone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
