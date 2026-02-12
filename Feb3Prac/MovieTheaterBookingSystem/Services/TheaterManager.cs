using System;
using MovieTheaterBookingSystem.Models;

namespace MovieTheaterBookingSystem.Services
{
    public class TheaterManager
    {
        private readonly List<MovieScreening> screenings=new();
        public void AddScreening(string title, DateTime time, string screen, int seats, double price)
        {
            screenings.Add(new MovieScreening
            {
                MovieTitle=title,
                ShowTime=time,
                TotalSeats=seats,
                ScreenNumber=screen,
                TicketPrice=price,
                BookedSeats=0
            });
        }

        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            var screening=screenings.FirstOrDefault(
                s=> s.MovieTitle.Equals(movieTitle,StringComparison.OrdinalIgnoreCase) && s.ShowTime==showTime);
            
            if(screening == null || screening.AvailableSeats < tickets)
            {
                return false;
            }

            screening.BookedSeats += tickets;
            return true;
        }

        public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
        {
            return screenings
                .GroupBy(s=>s.MovieTitle)
                .ToDictionary(g=>g.Key,g=> g.ToList());
        }

        public double CalculateTotalRevenue()
        {
            return screenings.Sum(s=>s.BookedSeats * s.TicketPrice);
        }

        public List<MovieScreening> GetAvailableScreenings(int minSeats)
        {
            return screenings
                .Where(s=> s.AvailableSeats >= minSeats)
                .ToList();
        }

        public List<MovieScreening> GetAllScreenings()
        {
            return screenings;
        }
    }
}