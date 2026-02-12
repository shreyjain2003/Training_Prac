using System;
using GymMembershipManagementSystem.Services;

namespace GymMembershipManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            GymManager manager = new GymManager();

            // Add members
            manager.AddMember("Alice", "Premium", 6);
            manager.AddMember("Bob", "Basic", 3);
            manager.AddMember("Charlie", "Platinum", 12);

            // Add fitness classes
            manager.AddClass("Yoga", "Emma", DateTime.Now.AddDays(2), 10);
            manager.AddClass("Zumba", "Liam", DateTime.Now.AddDays(5), 15);
            manager.AddClass("CrossFit", "Noah", DateTime.Now.AddDays(10), 8);

            // Register members
            manager.RegisterForClass(1, "Yoga");
            manager.RegisterForClass(2, "Yoga");
            manager.RegisterForClass(3, "Zumba");

            // Group members by membership type
            Console.WriteLine("=== Members Grouped By Membership Type ===");
            var groupedMembers = manager.GroupMembersByMembershipType();
            foreach (var group in groupedMembers)
            {
                Console.WriteLine($"Membership: {group.Key}");
                foreach (var member in group.Value)
                {
                    Console.WriteLine($"  {member.MemberId} - {member.Name}");
                }
            }

            // Upcoming classes
            Console.WriteLine("\n=== Upcoming Classes (Next 7 Days) ===");
            var upcomingClasses = manager.GetUpcomingClasses();
            foreach (var fitnessClass in upcomingClasses)
            {
                Console.WriteLine(
                    $"{fitnessClass.ClassName} | {fitnessClass.Schedule:g} | Instructor: {fitnessClass.Instructor}");
            }
        }
    }
}
