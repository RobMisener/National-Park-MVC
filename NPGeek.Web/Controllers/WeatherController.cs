using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;

namespace NPGeek.Web.Controllers
{
	public class WeatherController : Controller
	{
		IWeatherDAL dal;

        // GET: Weather

        //private static string parkCode;

		public WeatherController(IWeatherDAL dal)
		{
			this.dal = dal;
		}

		public ActionResult Index(string parkCode)
		{
			List<Weather> weathers = dal.GetWeatherByParkCode(parkCode);

            if (GetTempetureChoice() == "Celcius")
            {
                foreach(var weather in weathers)
                {
                    weather.IsCelcius = true;
                }
            }

            return PartialView("Index", weathers);
		}
            
        [HttpPost]
        public ActionResult Index(string tempUnit, string parkCode)
        {
            Session["TempChoice"] = tempUnit;

            return RedirectToAction("Detail","Park", new { parkCode = parkCode });
        }

        private string GetTempetureChoice()
        {
            string tempChoice = "Farenheight";

            if(Session["TempChoice"] == null)
            {
                Session["TempChoice"] = "Farenheight";
            }
            else
            {
                tempChoice = Session["TempChoice"] as string;
            }

            return tempChoice;
        }

	}




}