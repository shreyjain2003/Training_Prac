using System;
using System.Text.RegularExpressions;

/// <summary>
/// Password Generation using Regular Expressions
/// </summary>
class Program
{
    /// <summary>
    /// Entry point of the application
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Enter the username");
        string? username = Console.ReadLine();

        /// Validate null or empty input
        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username");
            return;
        }

        /// Validate username using REGEX
        if (!IsValidUsername(username))
        {
            Console.WriteLine($"{username} is an invalid username");
            return;
        }

        /// Generate and display password
        string password = GeneratePassword(username);
        Console.WriteLine($"Password: {password}");
    }

    /// <summary>
    /// Validates username using regex pattern
    /// </summary>
    /// <param name="username">Input username</param>
    /// <returns>true if valid, false otherwise</returns>
    static bool IsValidUsername(string username)
    {
        /// Regex explanation:
        /// ^            -> start of string
        /// [A-Z]{4}     -> exactly 4 uppercase letters
        /// [0-9]{4}     -> exactly 4 digits
        /// $            -> end of string
        string pattern = @"^[A-Z]{4}[0-9]{4}$";

        return Regex.IsMatch(username, pattern);
    }

    /// <summary>
    /// Generates password based on ASCII sum logic
    /// </summary>
    /// <param name="username">Valid username</param>
    /// <returns>Generated password</returns>
    static string GeneratePassword(string username)
    {
        /// Take first 4 characters and convert to lowercase
        string firstFour = username.Substring(0, 4).ToLower();

        /// Calculate ASCII sum
        int asciiSum = 0;
        foreach (char ch in firstFour)
        {
            asciiSum += ch;   // char automatically converts to ASCII value
        }

        /// Take last two digits of username
        string lastTwoDigits = username.Substring(6, 2);

        /// Construct final password
        return $"TECH_{asciiSum}{lastTwoDigits}";
    }
}
