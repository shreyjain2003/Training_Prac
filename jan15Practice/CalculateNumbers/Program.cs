using System;
namespace CalculateNumbers
{
    ///<summary>
    /// This class contains methods to calculate GPA and determine grade.
    ///</summary>
    public class Program
    {
        public static List<int> NumberList=new List<int>();   // List to store numbers

        /// <summary>
        /// Adds a number to the NumberList.
        /// </summary>
        public void AddNumber(int Numbers)
        {
            NumberList.Add(Numbers);
        }

        /// <summary>
        /// Calculates the GPA based on the numbers in NumberList.
        /// Each number is weighted by 3.
        /// </summary>
        public double GetGPAScored()
        {
            double total=0;

            if(NumberList.Count==0)
            {
                return -1;
            }
            foreach(var num in NumberList)
            {
                total+= (num *3);
            }
            return total/ (NumberList.Count*3);

        }

        /// <summary>
        /// Determines the grade based on the GPA.
        /// </summary>
        public char GetGradeScored(double gpa)
        {
            if (gpa < 5 || gpa > 10)
                return '\0';
            if(gpa>=5 && gpa<6)
            {
                return 'E';
            }
            else if(gpa>=6 && gpa <7)
            {
                return 'D';
            }
            else if(gpa>=7 && gpa <8)
            {
                return 'C';
            }
            else if(gpa>=8 && gpa <9)
            {
                return 'B';
            }
            else if(gpa>=9 && gpa <10)
            {
                return 'A';
            }
            else
            {
                return 'S';
            }
        }

        public static void Main()
        {
            Program p=new Program();
            p.AddNumber(7);
            p.AddNumber(5);
            p.AddNumber(9);

            double gpa=p.GetGPAScored();
            if(gpa<5 || gpa >10)
            {
                Console.WriteLine("Invalid GPA");
            }
            if (gpa == -1)
                Console.WriteLine("No Numbers Available");
            else
                Console.WriteLine(p.GetGradeScored(gpa));
        }
    }
}