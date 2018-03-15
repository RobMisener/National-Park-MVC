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
		string connectionString;
		string SQL_InsertIntoSurvey = @"INSERT INTO survey_result VALUES (@parkCode,@email,@state,@activityLevel)";
		
		public SurveyDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}
		
	//surveyId int identity(1,1) not null,
	//parkCode varchar(10) not null,
	//emailAddress varchar(100) not null,
	//state varchar(30) not null,
	//activityLevel varchar(100) not null,
	
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

		//get survey count of park by --- joined by 



	}
}