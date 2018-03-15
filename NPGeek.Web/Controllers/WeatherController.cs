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

		public WeatherController(IWeatherDAL dal)
		{
			this.dal = dal;
		}

		public ActionResult Index(string parkCode)
		{
			List<Weather> weather = dal.GetWeatherByParkCode(parkCode);

			return PartialView("Index", weather);
		}

		public ActionResult ChangeTempUnit(string parkCode, string tempUnit)
		{

			if (tempUnit.ToLower() == "celcius")
			{
				Weather.IsCelcius = true;
			}
			else
			{
				Weather.IsCelcius = false;
			}

			return RedirectToAction("Index","Weather", parkCode);
		}

	}




}