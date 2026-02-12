using System;
using System.Collections.Generic;

/// <summary>
/// This program calculates the total number of character deletions
/// required across BOTH words so that only common characters remain.
/// Comparison is case-sensitive.
/// </summary>
class Program
{
    static void Main()
    {
        // Read input words
        Console.Write("Enter word1: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter word2: ");
        string word2 = Console.ReadLine();

        // Frequency map for characters in word1
        Dictionary<char, int> freq1 = new Dictionary<char, int>();
        foreach (char c in word1)
        {
            if (freq1.ContainsKey(c))
                freq1[c]++;
            else
                freq1[c] = 1;
        }

        // Frequency map for characters in word2
        Dictionary<char, int> freq2 = new Dictionary<char, int>();
        foreach (char c in word2)
        {
            if (freq2.ContainsKey(c))
                freq2[c]++;
            else
                freq2[c] = 1;
        }

        int deletions = 0; // Total deletions required

        // Check characters from word1
        foreach (var item in freq1)
        {
            if (freq2.ContainsKey(item.Key))
            {
                // Extra occurrences must be deleted
                deletions += Math.Abs(item.Value - freq2[item.Key]);
            }
            else
            {
                // Character not present in word2 at all
                deletions += item.Value;
            }
        }

        // Check characters that exist only in word2
        foreach (var item in freq2)
        {
            if (!freq1.ContainsKey(item.Key))
            {
                deletions += item.Value;
            }
        }

        // Print final deletion count
        Console.WriteLine("Deletions required: " + deletions);
    }
}
