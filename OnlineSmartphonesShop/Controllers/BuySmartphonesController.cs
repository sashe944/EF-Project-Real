using OnlineSmartPhoneShop_DbContext;
using OnlineSmartPhoneShop_Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Postal;

namespace OnlineSmartphonesShop.Controllers
{
    public class BuySmartphonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: BuySmartphones
        public ActionResult Buy(string txtCount)
        {
            ViewBag.Count = txtCount;
            Session["Count"] = txtCount;
            return View();
        }
     
        public ActionResult MakeFinalizationInOrder(string returnedCount)
        {
            returnedCount = Session["Count"].ToString();
            String DevicePrice = Session["smartphonePrice"].ToString();
            ViewBag.TotalPrice = DevicePrice + " X " + returnedCount;
            ViewBag.smartphoneId = Session["smartphoneId"];

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeFinalizationInOrder(Order order,string emailAddress)
        {
            emailAddress = order.EmailAddress;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    //dynamic email = new Email("Example");
                    //email.To = emailAddress;
                    //email.Message = "Order has been made successfuly!";
                    //email.Send();
                    //return RedirectToAction("Buy");
                }
            }
            catch (DataException dex)
            {
                dex.Message.ToString();
                //Log the error (uncomment dex variable name and add a line here to write a log.   
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(order);
        }
    }
}