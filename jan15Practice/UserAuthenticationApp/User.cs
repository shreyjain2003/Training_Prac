using System;

namespace UserAuthenticationApp
{
    /// <summary>
    /// Represents a user in the authentication system.
    /// </summary>
    public class User
    {
        public string Name{get; set;}
        public string Password{get; set;}
        public string ConfirmationPassword{get; set;}
    }
}