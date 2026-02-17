using System;
using System.Linq;
namespace LinqPrac1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = {29,45,90,78,69,59,74};
            // int Count=0;
            // for(int i=0;i<arr.Length;i++)
            // {
            //     if(arr[i] > 40)
            //     {
            //         Count ++;
            //     }
            // }
            // int[] brr = new int[Count];
            // int index = 0;
            // for(int i=0;i<arr.Length;i++)
            // {
            //     if(arr[i] > 40)
            //     {
            //         brr[index] = arr[i];
            //         index++;
            //     }
            // }

            // Array.Sort(brr);
            // Array.Reverse(brr);
            
            // foreach(var i in brr)
            // {
            //     Console.Write(i+" ");
            // }

            var brr = from i in arr where i > 40 orderby i descending select i;
            foreach(int x in brr)
            {
                Console.Write(x + " ");
            }
        }
    }
}