using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString;

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetAllParks()
        {
            List<ParkModel> parks = new List<ParkModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    parks.Add(MapRowToList(reader));
                }
            }

            return parks;
        }

        private ParkModel MapRowToList(SqlDataReader reader)
        {
            return new ParkModel()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
        }
    }
}