using System;
using System.Security.Cryptography.X509Certificates;
using GymMembershipManagementSystem.Services;

namespace GymMembershipManagementSystem.Models
{
    public class FitnessClass
    {
        // - string ClassName
        // - string Instructor
        // - DateTime Schedule
        // - int MaxParticipants
        // - List<string> RegisteredMembers

        public string ClassName {get; set;}
        public string Instructor {get; set;}
        public DateTime Schedule {get; set;}
        public int MaxParticipants {get; set;}
        public List<int> RegisteredMembers {get; set;}=new();

    }
}