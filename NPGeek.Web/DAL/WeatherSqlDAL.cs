using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private string connectionString;

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<WeatherModel> GetWeather(string parkCode)
        {
            List<WeatherModel> parks = new List<WeatherModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode", conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    parks.Add(MapRowToWeather(reader));
                }
            }
            return parks;
        }

        private WeatherModel MapRowToWeather(SqlDataReader reader)
        {
            return new WeatherModel()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                Day = Convert.ToInt32(reader["fiveDayForcastValue"]),
                Low = Convert.ToInt32(reader["low"]),
                High = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
        }
    }
}