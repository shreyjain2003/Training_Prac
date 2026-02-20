using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string mac = "00:1A:2B:3C:4D:5E";
        string dateStr = "2026-02-19";
        string currStr = "$12,345.67";

        string Macpattern = @"^([0-9A-Fa-f]{2}[:-]){5}[0-9A-Fa-f]{2}$";
        string datePattern = @"^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|1[0-9]|2[0-9]|3[0-1])$";
        string Currency =  "^-?[$][0-9]{1,3}(,[0-9]{3})*([.][0-9]{2})?$";

        Console.WriteLine("Mac Matching: ");
        Console.WriteLine(Regex.IsMatch(mac, Macpattern));
        Console.WriteLine("Date Matching: ");
        Console.WriteLine(Regex.IsMatch(dateStr,datePattern));
        Console.WriteLine("Currency Checker: ");
        Console.WriteLine(Regex.IsMatch(currStr,Currency));
    }
}