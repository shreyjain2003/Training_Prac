using System;
namespace DelegatePrac1
{
    public delegate void DelegateAddNum1(int x, float y, double z);
    public delegate double DelagateAddNum2(int a, int b, int c);
    public delegate bool DelegateCheckLength(string str);
    public class Program
    {

        public static void AddNums1(int x, float y, double z)
        {
            Console.WriteLine(x + y + z);
        }
        public static double AddNums2(int a, int b, int c)
        {
            return a + b + c;
        }
        public static bool CheckLength(string str)
        {
            if (str.Length > 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void Main(string[] args)
        {
            DelegateAddNum1 obj1 = AddNums1;
            obj1.Invoke(1, 2.5f, 2.33);

            DelagateAddNum2 obj2 = AddNums2;
            double result = obj2.Invoke(2, 3, 3);
            Console.WriteLine(result);

            DelegateCheckLength obj3 = CheckLength;
            bool status = obj3.Invoke("shrey");
            Console.WriteLine(status);
        }
    }
}