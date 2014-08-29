using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TonyRobertsOrganist.Core.Repositories.Abstract;
using TonyRobertsOrganist.Core.Models;



namespace TonyRobertsOrganist.Core.Repositories.Concrete.Dummy
{
    public class DummyDiaryRepository// : IDiaryRepository
    {


        public static DiaryModel GetUpcomingEvents(DateTime from)
        {


            //TODO: Read in a text file

            DiaryModel diary = new DiaryModel();

            var events = new List<DiaryEvent>();

            //var event1 = new DiaryEvent();

            //event1.EventDate = DateTime.Now.AddDays(7).ToString("dd MMM yyyy");
            //event1.StartTime = "19:00";
            //event1.EndTime = "20:30";
            //event1.Location = "The Community Centre";
            //event1.AdditionalInformation = "Bring your own chair";

            //var event2 = new DiaryEvent();

            //event2.EventDate = DateTime.Now.AddDays(14).ToString("dd MMM yyyy");
            //event2.StartTime = "17:00";
            //event2.EndTime = "18:00";
            //event2.Location = "The Local Church";
            //event2.AdditionalInformation = "Arrive on time or not be let in. Tickets £5.00";

            //events.Add(event1);
            //events.Add(event2);

            diary.DiaryEvents = events;


            return diary;
            

        }



    }
}