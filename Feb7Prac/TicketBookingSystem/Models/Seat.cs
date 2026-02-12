using System;
namespace TicketBookingSystem.Models
{
    public class Seat
    {
        public int SeatNo {get; set;}
        public bool IsBooked {get; set;}
        public Seat(int seatNo)
        {
            SeatNo = seatNo;
            IsBooked = false;
        }
    }
}