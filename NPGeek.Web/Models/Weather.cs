using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class Weather
    {
		public static bool IsCelcius { get; set;}
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int DailyLow { get; set; } //low temp for day
        public int DailyHigh { get; set; } //high temp for day

		public int DisplayDailyLow
		{
			get
			{
				if (IsCelcius)
				{
					return ((DailyLow - 32) * (5 / 9));
				}
				else
				{
					return DailyLow;
				}
			}
		}

		public int DisplayDailyHigh
		{
			get
			{
				if (IsCelcius)
				{
					return ((DailyHigh - 32) * (5 / 9));
				}
				else
				{
					return DailyHigh;
				}
			}
		}


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

        public string ForecastMessage
        {

            get
            {
                if (ForeCast == "snow")
                {
                    return "You're gonna need some snow shoes, buddy.";
                }
                else if (ForeCast == "rain")
                {
                    return "Take an unmbrella, dude.";
                }
                else if (ForeCast == "thunderStorms")
                {
                    return "Stay safe. Seek shelter. Avoid high ridges, man.";
                }
                else if (ForeCast == "sunny")
                {
                    return "You should wear some sunscreen, missy.";
                }

                return "";
            }
        }

        public string TempetureMessage
        {
            get
            {
                if (DailyHigh > 75)
                {
                    return "Stay hydrated. Bring extra water, bro.";
                }
                else if (DailyHigh - DailyLow > 20)
                {
                    return "Wear breathable layers, pal.";
                }
                else if (DailyLow < 20)
                {
                    return "It is going to be cold, real cold. Staying in the cold for too long is bad.";
                }

                return "";
            }

        }

    }
}