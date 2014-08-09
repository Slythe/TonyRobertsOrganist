using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TonyRobertsOrganist.Core.Models;
using TonyRobertsOrganist.Core.Schedule;



namespace TonyRobertsOrganist.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Diary()
        {

            DiaryModel theDiary = ScheduleManager.GetDiaryInformation();
            
            return View(theDiary);
        }

    }
}