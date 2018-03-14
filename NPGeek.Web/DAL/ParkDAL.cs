using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
	public class ParkDAL
	{
		string connectionString;

		public ParkDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<Park> GetAllParks()
		{
			List<Park> output = new List<Park>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(@"Select * from park", conn);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Park park = new Park
						{
							ParkCode = Convert.ToString(reader["parkCode"]),
							Name = Convert.ToString(reader["parkName"]),
							State = Convert.ToString(reader["state"]),
							Acreage = Convert.ToInt32(reader["acreage"]),
							Elevation = Convert.ToInt32(reader["elevationInFeet"]),
							MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
							NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
							Climate = Convert.ToString(reader["climate"]),
							YearFounded = Convert.ToInt32(reader["yearFounded"]),
							AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
							InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
							ParkDescription = Convert.ToString(reader["parkDescription"]),
							EntryFee = Convert.ToInt32(reader["entryFee"]),
							AnimalSpecies = Convert.ToInt32(reader["animalSpecies"])
						};
						output.Add(park);
					}
					return output;
				}
			}
			catch (SqlException ex)
			{
				throw;
			}



		}

	}
}