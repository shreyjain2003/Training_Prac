using System;
using System.Linq.Expressions;
using GymMembershipManagementSystem.Models;

namespace GymMembershipManagementSystem.Services
{
    public class GymManager
    {

        private readonly List<Member> members=new();
        private readonly List<FitnessClass> classes=new();
        public int memberCounter=1;
        public void AddMember(string name, string membershipType, int months)
        {
            members.Add(new Member
            {
                MemberId=memberCounter++,
                Name=name,
                MembershipType=membershipType,
                JoinDate=DateTime.Today,
                ExpiryDate=DateTime.Today.AddMonths(months)
            });
        }

        public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
        {
            classes.Add(new FitnessClass
            {
                ClassName=className,
                Instructor=instructor,
                Schedule=schedule,
                MaxParticipants=maxParticipants
            });
        }

        public bool RegisterForClass(int memberId, string className)
        {
            var member =members.FirstOrDefault(m=> m.MemberId==memberId);
            var fitnessClass=classes.FirstOrDefault(c=> c.ClassName==className);

            if(member==null || fitnessClass == null)
            {
                return false;
            }

            if(fitnessClass.RegisteredMembers.Count >= fitnessClass.MaxParticipants)
            {
                return false;
            }

            if(fitnessClass.RegisteredMembers.Contains(memberId))
            {
                return false;
            }

            fitnessClass.RegisteredMembers.Add(memberId);
            return true;
        }

        public Dictionary<string, List<Member>> GroupMembersByMembershipType()
        {
            return members
                .GroupBy(m=> m.MembershipType)
                .ToDictionary(g=> g.Key, g=> g.ToList());
        }

        public List<FitnessClass> GetUpcomingClasses()
        {
            DateTime now=DateTime.Now;
            DateTime nextWeek=now.AddDays(7);

            return classes
                .Where(c=> c.Schedule >= now && c.Schedule <= nextWeek)
                .ToList();
        }
    }
}