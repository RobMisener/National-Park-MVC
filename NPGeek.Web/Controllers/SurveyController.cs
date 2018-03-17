using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.Models;
using NPGeek.Web.DAL;

namespace NPGeek.Web.Controllers
{

	//ar cheepo naro
    public class SurveyController : Controller
    {

		ISurveyDAL sDal;
        IParkDAL pDal;

		public SurveyController(ISurveyDAL sDal, IParkDAL pDal)
		{
			this.sDal = sDal;
            this.pDal = pDal;
		}

        // GET: Survey

        public ActionResult Survey()
		{
            List<Park> parks = pDal.GetAllParks();

            return View("Survey", parks);
        }

		[HttpPost]
		public ActionResult Survey(string parkCode, string email, string state, string activityLevel)
		{
            Survey survey = new Survey
            {
                ParkCode = parkCode,
                EmailAddress = email,
                State = state,
                ActivityLevel = activityLevel
            };

            sDal.InsertSurveyIntoTable(survey);
			return RedirectToAction("SurveyResult");
		}

        public ActionResult SurveyResult()
        {
            List<SurveyResult> results = sDal.GetSurveyCountOfParks();
            if (results != null)
            {
                return View("SurveyResult", results);
            }
            else
            {
                return View("SurveyResult");
            }
            
        }

    }
}