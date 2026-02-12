using System;
using System.Collections.Generic;

namespace FrequencyCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the Size of array: ");
            int n=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the elements: ");
            int[] arr=new int[n];
            for(int i=0;i<n;i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach(int num in arr)
            {
                if(frequency.ContainsKey(num))
                {
                    frequency[num]++;
                }
                else
                {
                    frequency[num] = 1;
                }
            }

            Console.WriteLine("Element Frequencies: ");
            foreach(var item in frequency)
            {
                Console.WriteLine($"{item.Key} -> {item.Value} times");
            }
        }
    }
}