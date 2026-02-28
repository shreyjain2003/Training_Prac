using Microsoft.Data.SqlClient;
using System.Data;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<string>> GetSourcesAsync()
        {
            var list = new List<string>();

            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("sp_GetSources", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            await conn.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(reader.GetString(0));
            }

            return list;
        }

        public async Task<List<string>> GetDestinationsAsync()
        {
            var list = new List<string>();

            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("sp_GetDestinations", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            await conn.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(reader.GetString(0));
            }

            return list;
        }

        public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
        {
            var list = new List<FlightResult>();

            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("sp_SearchFlights", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Source", source);
            cmd.Parameters.AddWithValue("@Destination", destination);
            cmd.Parameters.AddWithValue("@Persons", persons);

            await conn.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new FlightResult
                {
                    FlightId = reader.GetInt32(0),
                    FlightName = reader.GetString(1),
                    FlightType = reader.GetString(2),
                    Source = reader.GetString(3),
                    Destination = reader.GetString(4),
                    TotalCost = reader.GetDecimal(5)
                });
            }

            return list;
        }

        public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
        {
            var list = new List<FlightHotelResult>();

            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("sp_SearchFlightsWithHotels", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Source", source);
            cmd.Parameters.AddWithValue("@Destination", destination);
            cmd.Parameters.AddWithValue("@Persons", persons);

            await conn.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new FlightHotelResult
                {
                    FlightId = reader.GetInt32(0),
                    FlightName = reader.GetString(1),
                    Source = reader.GetString(2),
                    Destination = reader.GetString(3),
                    HotelName = reader.GetString(4),
                    TotalCost = reader.GetDecimal(5)
                });
            }

            return list;
        }
    }
}