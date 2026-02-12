using System;
using MovieTheaterBookingSystem.Services;

namespace MovieTheaterBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Movie Theater Booking System");

            TheaterManager manager=new TheaterManager();

            manager.AddScreening("Inception", DateTime.Today.AddHours(18), "Screen 1", 100, 250);
            manager.AddScreening("Inception", DateTime.Today.AddHours(21), "Screen 2", 80, 250);
            manager.AddScreening("Interstellar", DateTime.Today.AddHours(19), "Screen 3", 120, 300);

            // Book tickets
            manager.BookTickets("Inception", DateTime.Today.AddHours(18), 5);
            manager.BookTickets("Interstellar", DateTime.Today.AddHours(19), 10);

            //	View all screenings of a particular movie
            Console.WriteLine("\nScreenings Grouped by Movie: ");
            var grouped =manager.GroupScreeningsByMovie();
            foreach(var movie in grouped)
            {
                Console.WriteLine($"Movie: {movie.Key}");
                foreach(var screening in movie.Value)
                {
                    Console.WriteLine($" - ShowTime: {screening.ShowTime}, Screen: {screening.ScreenNumber}, Available Seats: {screening.AvailableSeats}");
                }
            }

            //	Check available screenings for group booking
            Console.WriteLine("\nAvailable Screenings for Group Booking (Min 15 Seats): ");
            var availableScreenings=manager.GetAvailableScreenings(15);
            foreach(var screening in availableScreenings)
            {
                Console.WriteLine($"Movie: {screening.MovieTitle}, ShowTime: {screening.ShowTime}, Screen: {screening.ScreenNumber}, Available Seats: {screening.AvailableSeats}");
            }
            //	Track revenue
            double totalRevenue=manager.CalculateTotalRevenue();
            Console.WriteLine("\nTotal Revenue: "+totalRevenue);
        }
    }
}