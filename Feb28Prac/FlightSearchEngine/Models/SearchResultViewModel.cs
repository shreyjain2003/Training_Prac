namespace FlightSearchEngine.Models
{
    public class SearchResultViewModel
    {
        public bool IsFlightOnly { get; set; }

        public List<FlightResult>? Flights { get; set; }

        public List<FlightHotelResult>? FlightHotels { get; set; }
    }
}