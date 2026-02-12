using System;
namespace SumCalculator
{
    public class Program
    {
        public static int Sum(int[] arr)
        {
            int sum=0;
            for(int i=0;i<arr.Length;i++)
            {
                sum+=arr[i];
            }
            return sum;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements you want to insert: ");
            int n=int.Parse(Console.ReadLine());
            int[] arr=new int[n];
            Console.WriteLine("Enter elements: ");
            for(int i=0;i<n;i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The sum of all elements: "+Sum(arr));
        }

    }
}