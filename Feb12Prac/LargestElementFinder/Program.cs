using System;

namespace LargestElementFinder
{
    public class Program
    {
        public static int FindLargestElement(int[] arr)
        {
            if(arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.");
            }
            int Largest = arr[0];
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i] > Largest)
                {
                    Largest = arr[i];
                }
            }
            return Largest;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in the array: ");
            int n=int.Parse(Console.ReadLine());
            int[] arr=new int[n];
            Console.WriteLine("Enter the elements of the array: ");
            for(int i=0;i<n;i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The largest element in the array is: "+FindLargestElement(arr));
        }
    }
}