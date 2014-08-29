using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TonyRobertsOrganist.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tuition()
        {
            return View();
        }

        public ActionResult PersonalRequests()
        {
            return View();
        }

        public ActionResult CareHomes()
        {
            return View();
        }

    }
}