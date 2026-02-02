using System;
using System.Collections.Generic;
using System.Linq;
using HotelRoomBookingSystem.Models;

namespace HotelRoomBookingSystem.Services
{
    public class HotelManager
    {
        private readonly List<Room> rooms=new();
        public void AddRoom (int roomNumber, string type, double price)
        {
            if(rooms.Any(r=>r.RoomNumber==roomNumber)) 
            {
                throw new Exception("Room. number already exists.");
            }

            rooms.Add(new Room
            {
                RoomNumber=roomNumber,
                RoomType=type,
                PricePerNight=price,
                IsAvailable=true
            });
        }

        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            return rooms.
                Where(r=> r.IsAvailable)
                .GroupBy(r=> r.RoomType)
                .ToDictionary(g=> g.Key,g=> g.ToList());
        }

        public bool BookRoom(int roomNumber, int nights)
        {
            Room room=rooms.FirstOrDefault(r=> r.RoomNumber==roomNumber);
            if( room==null  || !room.IsAvailable)
            {
                return false;
            }

            double totalCost=room.PricePerNight * nights;
            room.IsAvailable=false;

            Console.WriteLine($"Room {roomNumber} booked successfully!");
            Console.WriteLine($"Total cost for {nights} nights: {totalCost}");
            return true;
        }

        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            return rooms
            .Where(r=> r.IsAvailable && r.PricePerNight >= min && r.PricePerNight <= max)
            .ToList();
        }


    }
}