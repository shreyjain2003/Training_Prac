using System;
using System.Security.Cryptography.X509Certificates;
using GymMembershipManagementSystem.Services;

namespace GymMembershipManagementSystem.Models
{
    public class Member
    {
        public int MemberId {get; set;}
        public string Name {get; set;}
        public string MembershipType {get; set;}
        public DateTime JoinDate {get; set;}
        public DateTime ExpiryDate {get; set;}
    }
}