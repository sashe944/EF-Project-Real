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

namespace OnlineSmartphonesShop.Controllers
{
    public class BuySmartphonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuySmartphones
        public ActionResult Index()
        {
            return View(db.BuySmartphones.ToList());
        }

        // GET: BuySmartphones/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySmartphone buySmartphone = db.BuySmartphones.Find(id);
            if (buySmartphone == null)
            {
                return HttpNotFound();
            }
            return View(buySmartphone);
        }

        // GET: BuySmartphones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuySmartphones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SmartphoneName,Price,ImgURL,BoughtOnDate")] BuySmartphone buySmartphone)
        {
            if (ModelState.IsValid)
            {
                db.BuySmartphones.Add(buySmartphone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buySmartphone);
        }

        // GET: BuySmartphones/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySmartphone buySmartphone = db.BuySmartphones.Find(id);
            if (buySmartphone == null)
            {
                return HttpNotFound();
            }
            return View(buySmartphone);
        }

        // POST: BuySmartphones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SmartphoneName,Price,ImgURL,BoughtOnDate")] BuySmartphone buySmartphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buySmartphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buySmartphone);
        }

        // GET: BuySmartphones/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySmartphone buySmartphone = db.BuySmartphones.Find(id);
            if (buySmartphone == null)
            {
                return HttpNotFound();
            }
            return View(buySmartphone);
        }

        // POST: BuySmartphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BuySmartphone buySmartphone = db.BuySmartphones.Find(id);
            db.BuySmartphones.Remove(buySmartphone);
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
