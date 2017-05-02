using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSmartphonesShop.Controllers
{
    public class BuyOrSellController : Controller
    {
        // GET: BuyOrSell
        public ActionResult Buy()
        {
            return View();
        }
        public ActionResult Sell()
        {
            return View();
        }
    }
}