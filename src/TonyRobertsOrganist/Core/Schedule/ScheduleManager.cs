using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TonyRobertsOrganist.Core.Models;
using TonyRobertsOrganist.Core.Infrastructure;
using TonyRobertsOrganist.Core.Repositories.Abstract;
using TonyRobertsOrganist.Core.Repositories.Concrete;



namespace TonyRobertsOrganist.Core.Schedule
{
    public class ScheduleManager
    {


        public static DiaryModel GetDiaryInformation()
        {

            DiaryModel UpcomingShows = Repositories.Concrete.Dummy.DummyDiaryRepository.GetUpcomingEvents(DateTime.Now);

            return UpcomingShows;


        }


    }
}