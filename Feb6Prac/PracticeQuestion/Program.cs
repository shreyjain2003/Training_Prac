using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        while (s.Length > 0)
        {
            char ch = s[0];
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ch)
                    count++;
            }

            Console.WriteLine(ch + " : " + count);

            s = s.Replace(ch.ToString(), "");
        }
    }
}
