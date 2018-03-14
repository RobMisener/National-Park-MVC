using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
	public class Weather
	{
		public string ParkCode { get; set; }
		public int FiveDayForecastValue { get; set; }
		public int DailyLow { get; set; } //low temp for day
		public int DailyHigh { get; set; } //high temp for day
		public string ForeCast { get; set; } //sunny, cloudy, etc

		public string ImageName
		{
			get
			{
				if (ForeCast == "partly cloudy")
				{
					return "partlyCloudy";
				}
				else
				{
					return ForeCast;
				}
			}
		}

	}
}