using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace TonyRobertsOrganist.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Albums()
        {

            //Set the paypal variables
            ViewBag.PayPalUrl = ConfigurationManager.AppSettings["Paypal.URL"];
            ViewBag.PayPalMerchantEmailAddress = ConfigurationManager.AppSettings["Paypal.Merchant.EmailAddress"];
            ViewBag.TonyRobertsLiveGrossPrice = ConfigurationManager.AppSettings["Albums.TonyRobertsLive.GrossPrice"];

            return View();

        }

    }
}