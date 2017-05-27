using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSmartphonesShop.Controllers
{
    public class BuySmartphonesController : Controller
    {
        // GET: BuySmartphones
        public ActionResult Buy(string txtCount)
        {
            ViewBag.Count = txtCount;
            Session["Count"] = txtCount;
            return View();
        }
        public ActionResult Order(string returnedCount)
        {
            returnedCount = Session["Count"].ToString();
            String DevicePrice = Session["smartphonePrice"].ToString();
            ViewBag.TotalPrice = DevicePrice + " X "  + returnedCount;
            return View();
        }
    }
}