using System;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public class RentalManager
    {

        private readonly List<RentalCar> cars = new();
        private readonly List<Rental> rentals = new();
        private int rentalCounter = 1;
        public void AddCar(string license, string make, string model, string type, double rate)
        {
            cars.Add(new RentalCar
            {
                LicensePlate = license,
                Make = make,
                Model = model,
                CarType = type,
                DailyRate = rate,
                IsAvailable = true
            });
        }

        // Creates rental if car available
        public bool RentCar(string license, string customer, DateTime start, int days)
        {
            var car = cars.FirstOrDefault(c => c.LicensePlate == license && c.IsAvailable);
            if (car == null)
            {
                return false;
            }

            var rental = new Rental
            {
                RentalId = rentalCounter++,
                LicensePlate = license,
                CustomerName = customer,
                StartDate = start,
                EndDate = start.AddDays(days),
                TotalCost = days * car.DailyRate
            };
            car.IsAvailable = false;
            rentals.Add(rental);
            return true;
        }

        public Dictionary<string, List<RentalCar>> GroupCarsByType()
        {
            return cars
                .Where(c => c.IsAvailable)
                .GroupBy(c => c.CarType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Rental> GetActiveRentals()
        {
            return rentals
            .Where(r=> r.EndDate >= DateTime.Now)
            .ToList();
        }

        public double CalculateTotalRentalRevenue()
        {
            return rentals.Sum(r=> r.TotalCost);
        }
    }
}