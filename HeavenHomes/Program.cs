using System;

namespace HeavenHomes
{
    public class Apartment
    {
        private Dictionary<string,double> apartmentDetailsDict=new Dictionary<string,double>();

        public void addApartmentDetails(string apartmentNumber,double rent)
        {
            apartmentDetailsDict.Add(apartmentNumber,rent);
        }

        public double FindTotalRentOfApartmentsinTheGivenRange(double minimumRent, double maximumRent)
        {
            double result=0;
            result=apartmentDetailsDict.Where(x=> x.Value>=minimumRent && x.Value<=maximumRent).Sum(x=>x.Value);
            return result;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the numeber of details to be added: ");
            int number=int.Parse(Console.ReadLine());

            Apartment apartment=new Apartment();
            if(number <= 0)
            {
                Console.WriteLine("No Apartment Details Found!");
                return;
            }
            Console.WriteLine("Enter the apartment details (ApartmentNumber:Rent): ");
            for(int i=0;i<number;i++)
            {
                string ap=Console.ReadLine();
                string[] apartmentDetails=ap.Split(":");
                apartment.addApartmentDetails(apartmentDetails[0],double.Parse(apartmentDetails[1]));
            }

            Console.WriteLine("Enter the minimum and maximum rent to filter apartments (separated by a colon): ");
            string[] rentRange=Console.ReadLine().Split(":");
            double minRent=double.Parse(rentRange[0]);
            double maxRent=double.Parse(rentRange[1]);
            double totalRent=apartment.FindTotalRentOfApartmentsinTheGivenRange(minRent,maxRent);
            if(totalRent==0)
            {
                Console.WriteLine("No Apartment Details Found!");
                return;
            }
            Console.WriteLine($"Total Rent in the range {minRent} to {maxRent} USD: {totalRent}");
        }
    }
}