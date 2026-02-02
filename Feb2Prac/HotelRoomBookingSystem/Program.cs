using System;
using HotelRoomBookingSystem.Services;

namespace HotelRoomBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HotelManager hotel=new HotelManager();
            hotel.AddRoom(101,"Single",1000);
            hotel.AddRoom(102,"Double",1500);
            hotel.AddRoom(201,"Suite",3000);
            hotel.AddRoom(202,"Single",2600);

            Console.WriteLine("Available rooms Group by Types: ");
            var grouped=hotel.GroupRoomsByType();
            foreach(var type in grouped)
            {
                Console.WriteLine($"\n{type.Key}:");
                foreach(var room in type.Value)
                {
                    Console.WriteLine($"- Room {room.RoomNumber} | ₹{room.PricePerNight}/night");
                }
            }
            Console.WriteLine("\nBooking Room 102 for 3 nights:");
            hotel.BookRoom(102, 3);      

            Console.WriteLine("\nAvailable Rooms between ₹2500 and ₹5000:");
            var budgetRooms = hotel.GetAvailableRoomsByPriceRange(2500, 5000);

            foreach (var room in budgetRooms)
            {
                Console.WriteLine($"- Room {room.RoomNumber} ({room.RoomType})");
            }          
        }

    }
}