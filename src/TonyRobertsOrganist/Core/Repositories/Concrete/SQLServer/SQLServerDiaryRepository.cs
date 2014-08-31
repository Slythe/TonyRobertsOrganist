using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TonyRobertsOrganist.Core.Models;



namespace TonyRobertsOrganist.Core.Repositories.Concrete.SQLServer
{
    public class SQLServerDiaryRepository
    {


        public static bool ImportDiaryEvents(DataSet eventsSchedule)
        {

            bool imported = false;

            try
            {

                DeleteAllDiaryEvents();

                foreach (DataRow dr in eventsSchedule.Tables[0].Rows)
                {

                    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tro"].ConnectionString))
                    using (var command = new SqlCommand("EventsSchedule_ImportEvent", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {

                        conn.Open();

                        SqlParameter prmDate = command.Parameters.Add("@Date", SqlDbType.DateTime);
                        prmDate.Value = dr["Date"];

                        SqlParameter prmStartTime = command.Parameters.Add("@StartTime", SqlDbType.DateTime);
                        prmStartTime.Value = dr["StartTime"];

                        SqlParameter prmEndTime = command.Parameters.Add("@EndTime", SqlDbType.DateTime);
                        prmEndTime.Value = dr["EndTime"];

                        command.Parameters.Add(new SqlParameter("@Location", dr["Location"]));
                        command.Parameters.Add(new SqlParameter("@AdditionalInformation", dr["AdditionalInformation"]));

                        command.ExecuteNonQuery();
                        conn.Close();

                    }
                    
                }

                imported = true;

            }
            catch(Exception e)
            {

                imported = false;

            }
                       

            return imported;


        }


        public static void DeleteAllDiaryEvents()
        {

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tro"].ConnectionString))
            using (var command = new SqlCommand("EventsSchedule_DeleteAll", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

            }

        }


        public static DiaryModel GetUpcomingEvents(DateTime from)
        {

            DiaryModel diary = new DiaryModel();

            var events = new List<DiaryEvent>();


            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tro"].ConnectionString))
            using (var command = new SqlCommand("EventsSchedule_GetUpcomingEvents", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                conn.Open();

                SqlParameter prmDate = command.Parameters.Add("@FromDate", SqlDbType.DateTime);
                prmDate.Value = from;
                
                using (SqlDataReader dr = command.ExecuteReader())
                {

                    DiaryEvent scheduleItem;

                    while (dr.Read())
                    {

                        scheduleItem = new DiaryEvent();

                        scheduleItem.EventDate = Convert.ToDateTime(dr["Date"]).ToString("dd MMM yyyy");
                        scheduleItem.StartTime = Convert.ToDateTime(dr["StartTime"]).ToString("HH:mm");
                        scheduleItem.EndTime = Convert.ToDateTime(dr["EndTime"]).ToString("HH:mm");
                        scheduleItem.Location = Convert.ToString(dr["Location"]);
                        scheduleItem.AdditionalInformation = Convert.ToString(dr["AdditionalInformtaion"]);

                        events.Add(scheduleItem);

                    }

                }
                

                command.ExecuteNonQuery();
                conn.Close();

            }


            diary.DiaryEvents = events;


            return diary;


        }



        public static DiaryEvent GetNextEvent()
        {


            DiaryEvent scheduleItem = null;


            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tro"].ConnectionString))
            using (var command = new SqlCommand("EventsSchedule_GetNext", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                conn.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {


                    while (dr.Read())
                    {

                        scheduleItem = new DiaryEvent();

                        scheduleItem.EventDate = Convert.ToDateTime(dr["Date"]).ToString("dd MMM yyyy");
                        scheduleItem.StartTime = Convert.ToDateTime(dr["StartTime"]).ToString("HH:mm");
                        scheduleItem.EndTime = Convert.ToDateTime(dr["EndTime"]).ToString("HH:mm");
                        scheduleItem.Location = Convert.ToString(dr["Location"]);
                        scheduleItem.AdditionalInformation = Convert.ToString(dr["AdditionalInformtaion"]);


                    }

                }


                command.ExecuteNonQuery();
                conn.Close();

            }


            return scheduleItem;


        }


    }
}