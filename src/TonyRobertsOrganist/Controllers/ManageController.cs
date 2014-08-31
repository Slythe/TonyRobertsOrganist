using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using H2eCommerce.Libraries.StructuredFileReaders.Core.FileParsing;
using TonyRobertsOrganist.Core.Schedule;
using TonyRobertsOrganist.Core.Models.Manage;


namespace TonyRobertsOrganist.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DiaryUpload(HttpPostedFileBase file)
        {


            var importResult = new ManageImportResultModel();
            importResult.ImportCompleted = false;


            if (file != null)
            {                           
                                
                if (file.ContentLength > 0)
                {

                    //Save file
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), filename);

                    file.SaveAs(path);

                    //Import
                    var fileReader = new ImportFileParser(path, true);
                    fileReader.ParseFile();

                    if (fileReader.FileReadSuccessfully)
                    {

                        bool imported = ScheduleManager.ImportEventsSchedule(fileReader.DataSetWithImportFileData);

                        if (imported)
                        {

                            importResult.ImportCompleted = true;

                        }
                        else
                        {

                            importResult.ErrorMessage = "There was an error adding events to the database";

                        }

                    }else{

                        importResult.ErrorMessage = "There was an error reading the imported file. Error message: " + fileReader.ExceptionMessage;

                    }


                    
                } else {
                    
                    importResult.ErrorMessage = "Please select a file first";

                }

                return View("DiaryUpload", importResult);

            }
            else
            {

                return View();

            }
            
            
        }
        

    }
}