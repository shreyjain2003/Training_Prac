using System;
using System.Collections;

namespace YogaMeditationApp
{
    /// <summary>
    /// Program class to manage Yoga Meditation Centre members
    /// </summary>
    public class Program
    {
        public static ArrayList memberList=new ArrayList();  // List to store members of the meditation centre

        public void AddYogaMember(int memberId, int age, double weight, double height, string goal) // Method to add a new Yoga member
        {
            memberList.Add(new MeditationCentre
                {
                    MemberId=memberId,
                    Age=age,
                    Weight=weight,
                    Height=height,
                    Goal=goal
                }
            );
        }

        /// <summary>
        /// Calculates and returns the BMI for a member
        /// reference to the memberId
        /// </summary>
        public double CalculateBMI(int memberId)
        {
            foreach(MeditationCentre member in memberList)
            {
                if(member.MemberId==memberId)
                {
                    double bmi = member.Weight / (member.Height * member.Height);
                    member.BMI = Math.Floor(bmi * 100) / 100;
                    return member.BMI;
                }
            }
            return 0;
        }

        /// <summary>
        /// Calculates and returns the fee for a Yoga member
        /// reference to the memberId
        /// </summary>
        public int CalculateYogaFee(int memberId)
        {
            /// Calculates and returns the fee for a Yoga member
            /// reference to the memberId
            foreach(MeditationCentre member in memberList)
            {
                if(member.MemberId==memberId){
                if(member.Goal.Equals("Weight Loss"))
                {
                    if(member.BMI>=25 && member.BMI <30)
                    {
                        return 2000;
                    }
                    else if(member.BMI>=30 && member.BMI <35)
                    {
                        return 2500;
                    }
                    else if(member.BMI>=35)
                    {
                        return 3000;
                    }
                }
                else if(member.Goal.Equals("Weight Gain"))
                {
                    return 2500;
                }
                }
            }
            return 0;
            
        }

        /// <summary>
        /// Main method to test the Yoga Meditation App functionality
        /// </summary>
        public static void Main()
        {
            Program p=new Program();
            p.AddYogaMember(101, 28, 85, 1.68, "Weight Loss");
            p.AddYogaMember(102, 32, 70, 1.68, "Weight Gain");  

            Console.WriteLine("BMI of member 101: " + p.CalculateBMI(101));
            Console.WriteLine("Yoga Fee of member 101: " + p.CalculateYogaFee(101));

            Console.WriteLine("BMI of member 102: " + p.CalculateBMI(102));
            Console.WriteLine("Yoga Fee of member 102: " + p.CalculateYogaFee(102));

        }
        
    }
}