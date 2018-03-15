using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString;

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SurveyModel> GetAllParksInOrderByCount()
        {
            List<SurveyModel> survey = new List<SurveyModel>();

            string query = "SELECT parkCode, COUNT(surveyId) as TotalSurvey FROM survey_result " +
                           "GROUP BY parkCode " +
                           "ORDER BY TotalSurvey DESC; ";
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    survey.Add(MapRowToSurveyAnswer(reader));
                }
            }
            return survey;
        }

        public bool SubmitSurvey(SurveyModel survey)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO survey_result VALUES (@parkcode, @email, @state, @activitylevel);", conn);

                cmd.Parameters.AddWithValue("@parkcode", survey.ParkCode);
                cmd.Parameters.AddWithValue("@email", survey.EmailAddress);
                cmd.Parameters.AddWithValue("@state", survey.State);
                cmd.Parameters.AddWithValue("@activitylevel", survey.ActivityLevel);

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        private SurveyModel MapRowToSurvey(SqlDataReader reader)
        {
            return new SurveyModel()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                EmailAddress = Convert.ToString(reader["emailAddress"]),
                State = Convert.ToString(reader["state"]),  
                ActivityLevel = Convert.ToString(reader["activityLevel"])
            };
        }
        private SurveyModel MapRowToSurveyAnswer(SqlDataReader reader)
        {
            return new SurveyModel()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                SurveyRank = Convert.ToInt32(reader["TotalSurvey"]) 
            };
        }
    }
}