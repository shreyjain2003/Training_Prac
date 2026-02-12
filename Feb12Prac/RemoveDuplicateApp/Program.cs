using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveDuplicateApp
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int> {1,2,2,3,4,5,5,6,7,7,8};
            HashSet<int> uniqueSet = new HashSet<int>(numbers);
            List<int> uniqueList = uniqueSet.ToList();
            Console.WriteLine("Origimal List: "+string.Join(", ",numbers));
            Console.WriteLine("List after removing duplicates: "+string.Join(", ",uniqueList));
        }
    }
}