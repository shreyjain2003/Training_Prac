using System;
using CarRentalSystem.Services;
using CarRentalSystem.Models;

namespace CarRentalSystem
{
    class Program
    {
        static void Main()
        {
            var manager = new RentalManager();

            // Add cars
            manager.AddCar("UP14AB1234", "Toyota", "Corolla", "Sedan", 1500);
            manager.AddCar("DL01XY5678", "Hyundai", "Creta", "SUV", 2500);
            manager.AddCar("MH12ZZ9999", "Tata", "Winger", "Van", 3000);

            // Rent a car
            manager.RentCar("UP14AB1234", "Rahul Sharma", DateTime.Now, 3);

            // Group cars by type
            var groupedCars = manager.GroupCarsByType();
            Console.WriteLine("Available Cars by Type:");
            foreach (var type in groupedCars)
            {
                Console.WriteLine($"{type.Key}: {type.Value.Count}");
            }

            // Active rentals
            Console.WriteLine("\nActive Rentals:");
            foreach (var rental in manager.GetActiveRentals())
            {
                Console.WriteLine($"{rental.CustomerName} - {rental.LicensePlate}");
            }

            // Total revenue
            Console.WriteLine($"\nTotal Revenue: ₹{manager.CalculateTotalRentalRevenue()}");
        }
    }
}
