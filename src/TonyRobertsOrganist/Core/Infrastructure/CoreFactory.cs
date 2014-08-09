using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TonyRobertsOrganist.Core.Repositories.Abstract;
using TonyRobertsOrganist.Core.Repositories.Concrete;



namespace TonyRobertsOrganist.Core.Infrastructure
{
    public class CoreFactory
    {


        //private IDiaryRepository _DiaryRepository = new Repositories.Concrete.Dummy.DummyDiaryRepository();


        //public IDiaryRepository DiaryRepository
        //{ 
        //    get
        //    {
        //        return _DiaryRepository;
        //    } 
        //    set
        //    {
        //        _DiaryRepository = value;
        //    }
        //}
        


        //private void InitialiseRepositories()
        //{

        //    //Hardcode for now
        //    DiaryRepository = new Repositories.Concrete.Dummy.DummyDiaryRepository();


        //}



        public void StartCore()
        {

            //InitialiseRepositories();

        }



    }
}