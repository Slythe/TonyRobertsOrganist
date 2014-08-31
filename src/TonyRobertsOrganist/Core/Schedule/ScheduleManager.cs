using System;
using System.Data;
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

            return Repositories.Concrete.SQLServer.SQLServerDiaryRepository.GetUpcomingEvents(DateTime.Now);

        }


        public static bool ImportEventsSchedule(DataSet eventsSchedule)
        {

            return Repositories.Concrete.SQLServer.SQLServerDiaryRepository.ImportDiaryEvents(eventsSchedule);

        }


        public static DiaryEvent GetNextEvent()
        {

            return Repositories.Concrete.SQLServer.SQLServerDiaryRepository.GetNextEvent();

        }
        

    }
}