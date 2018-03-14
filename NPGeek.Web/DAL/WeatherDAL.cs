using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
	public class WeatherDAL : IWeatherDAL
	{
		string connectionString;

		const string SQL_SelectWeatherByParkCode = ("@Select * from weather where parkCode = @parkCode;");

		public WeatherDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<Weather> GetWeatherByParkCode(string parkCode)
		{
			List<Weather> weathers = new List<Weather>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand(SQL_SelectWeatherByParkCode, conn);
					cmd.Parameters.AddWithValue("@parkCode", parkCode);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Weather weather = MapWeatherFromReader(reader);
						weathers.Add(weather);
					}

					return weathers;
				}

			}
			catch(SqlException)
			{
				throw;
			}
		}

		private Weather MapWeatherFromReader(SqlDataReader reader)
		{
			Weather weather = new Weather
			{
				ParkCode = Convert.ToString(reader["parkCode"]),
				FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
				DailyLow = Convert.ToInt32(reader["low"]),
				DailyHigh = Convert.ToInt32(reader["high"]),
				ForeCast = Convert.ToString(reader["forecast"])
			};

			return weather;
		}
	}
}