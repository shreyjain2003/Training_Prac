using System;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Services
{
    public class TicketBookingService
    {
        private readonly Dictionary<int, Seat> _seats;
        private readonly object _lock = new();

        public TicketBookingService(int seatCount)
        {
            _seats = new Dictionary<int, Seat>();
            for(int i=1;i <= seatCount; i++)
            {
                _seats[i] = new Seat(i);
            }
        }
        public bool BookSeat(int seatNo, string userId)
        {
            lock(_lock)
            {
                if(!_seats.ContainsKey(seatNo))
                {
                    throw new ArgumentException("Invalid Seat Number");
                }
                if(_seats[seatNo].IsBooked)
                {
                    return false;
                }
                _seats[seatNo].IsBooked = true;
                return true;
            }
        }
    }   
}