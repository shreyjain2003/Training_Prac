using System;
using System.ComponentModel;
using System.IO.Pipelines;

namespace BakeMeAWish
{
    /// <summary>
    /// Class to handle cake orders
    /// </summary>
    public class CakeOrder
    {
        private Dictionary<string, double> orderDict=new Dictionary<string, double>();  // To store orderId and cakeCost

        public void AddOrder(string OrderId, double CakeCost) // Method to add order details
        {
            orderDict.Add(OrderId, CakeCost);
        }

        public Dictionary<string, double> FindOrdersAboveSpecifiedCost(double CakeOrder) // Method to find orders above specified cost  
        {
            var result=orderDict.Where(x=> x.Value>CakeOrder).ToDictionary();
            return result;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of Orders: ");
            int number=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the cake order details (OrderId:CakeCost)");
            CakeOrder cakeorder=new CakeOrder();
            if(number<=0)
            {
                Console.WriteLine("No Cake Orders Found!");
                return;
            }
            for( int i=0;i<number;i++)
            {
                string order=Console.ReadLine();
                string[] orderDetails=order.Split(":");
                cakeorder.AddOrder(orderDetails[0],double.Parse(orderDetails[1]));
            }

            Console.WriteLine("Enter the cake cost to filter orders: ");
            double cost=double.Parse(Console.ReadLine());
            var result=cakeorder.FindOrdersAboveSpecifiedCost(cost);

            if(result.Count==0)
            {
                Console.WriteLine("No Cake Orders Found!");
                return;
            }
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}