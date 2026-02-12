using System;
using System.Threading.Tasks;
using TicketBookingSystem.Services;
namespace TicketBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new TicketBookingService(1);
            Parallel.For(0, 5, i =>
            {
                bool result = service.BookSeat(1,$"User{i}");
                Console.WriteLine($"User{i} booking result: {result}");
            });

        }
    }
}