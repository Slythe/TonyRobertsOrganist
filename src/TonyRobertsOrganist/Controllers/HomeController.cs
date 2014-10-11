using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TonyRobertsOrganist.Core.Models;
using TonyRobertsOrganist.Core.Schedule;
using System.Configuration;


namespace TonyRobertsOrganist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            DiaryEvent nextEvent = ScheduleManager.GetNextEvent();

            return View("Index", nextEvent);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            
            return View();
        }
    }
}