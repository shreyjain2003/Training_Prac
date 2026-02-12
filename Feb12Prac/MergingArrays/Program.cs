using System;
namespace MergingArrays
{
    public class Program
    {
        public static void Merge(int[] arr1, int[] arr2)
        {
            int[] resArray = new int[arr1.Length + arr2.Length];

            for(int i = 0; i < arr1.Length; i++)
            {
                resArray[i] = arr1[i];
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                resArray[arr1.Length + i] = arr2[i];
            }
            Array.Sort(resArray);
            Console.WriteLine("Merged Sorted Array: ");
            foreach(int num in resArray)
            {
                Console.Write(num + " ");
            }
        }
        public static void Main(string[] args)
        {
            int[] arr1 = null;
            int[] arr2 = null;
            int n = 0;
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"Enter the number of elements in Array{i}");
                n = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    arr1 = new int[n];
                    Console.WriteLine($"Enter the elemnts in Array{i}: ");
                    for (int j = 0; j < n; j++)
                    {
                        arr1[j] = int.Parse(Console.ReadLine());
                    }
                }
                else
                {
                    arr2 = new int[n];
                    Console.WriteLine($"Enter the elemnts in Array{i}: ");
                    for (int j = 0; j < n; j++)
                    {
                        arr2[j] = int.Parse(Console.ReadLine());
                    }
                }
            }

            Array.Sort(arr1);
            Array.Sort(arr2);
            Merge(arr1, arr2);
        }
    }
}