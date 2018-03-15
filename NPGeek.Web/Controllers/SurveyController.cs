using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.Models;
using NPGeek.Web.DAL;

namespace NPGeek.Web.Controllers
{


    public class SurveyController : Controller
    {

		ISurveyDAL dal;

		public SurveyController(ISurveyDAL dal)
		{
			this.dal = dal;
		}

        // GET: Survey

        public ActionResult Survey()
		{
            return View("Survey");
        }

		[HttpPost]
		public ActionResult Survey(Survey survey)
		{
			dal.InsertSurveyIntoTable(survey);
			return RedirectToAction("SurveyResult", survey);
		}


    }
}