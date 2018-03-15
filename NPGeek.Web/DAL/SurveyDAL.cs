using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
	public class SurveyDAL : ISurveyDAL
	{
		private string connectionString;
		const string SQL_InsertIntoSurvey = @"INSERT INTO survey_result VALUES (@parkCode, @email, @state, @activityLevel)";
        const string SQL_SelectSurveyCountByParkCode =
            @"SELECT count(parkName) as surveyCount, park.parkCode, parkName from survey_result " +
            "join park on survey_result.parkCode = park.parkCode " +
            "group by parkname, park.parkCode ORDER BY surveyCount DESC;";


        public SurveyDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}
	
		public bool InsertSurveyIntoTable(Survey survey)
		{

			try
			{
				using(SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(SQL_InsertIntoSurvey, conn);
					cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
					cmd.Parameters.AddWithValue("@email", survey.EmailAddress);
					cmd.Parameters.AddWithValue("@state", survey.State);
					cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
					
					cmd.ExecuteNonQuery();
					return true;
				}

			}
			catch(SqlException)
			{
				return false;
			}

		}

		public List<SurveyResult> GetSurveyCountOfParks()
        {
            List<SurveyResult> results = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SelectSurveyCountByParkCode, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult result = new SurveyResult
                        {
                            SurveyCount = Convert.ToInt32(reader["surveyCount"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"])
                        };

                        results.Add(result);
                    }

                    return results;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }



	}
}