using System;

namespace HotelRoomBookingSystem.Models
{
    public class Room
    {
        public int RoomNumber {get; set;}
        public string RoomType {get; set;}
        public double PricePerNight {get; set;}
        public bool IsAvailable {get; set;}
    }
}