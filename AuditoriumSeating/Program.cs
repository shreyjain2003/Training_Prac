using System;
using System.Collections.Generic;

/// <summary>
/// Auditorium Seating Allocation
/// VIP delegates are seated first, followed by normal delegates.
/// </summary>
class Program
{
    static void Main()
    {
        // -----------------------------
        // STEP 1: Auditorium Layout
        // -----------------------------
        char[,] hall =
        {
            { '.', 'V', '.', '#' },
            { '.', '.', 'V', '.' },
            { '#', '.', '.', '.' }
        };

        int vipDelegates = 2;
        int normalDelegates = 5;

        // -----------------------------
        // STEP 2: Collect seats
        // -----------------------------
        Queue<(int r, int c)> vipSeats = new();
        Queue<(int r, int c)> normalSeats = new();

        int rows = hall.GetLength(0);
        int cols = hall.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (hall[i, j] == 'V')
                    vipSeats.Enqueue((i, j));
                else if (hall[i, j] == '.')
                    normalSeats.Enqueue((i, j));
            }
        }

        // -----------------------------
        // STEP 3: Seat VIP delegates
        // -----------------------------
        int vipSeated = 0;

        while (vipDelegates > 0 && vipSeats.Count > 0)
        {
            var seat = vipSeats.Dequeue();
            hall[seat.r, seat.c] = 'X'; // VIP seated
            vipDelegates--;
            vipSeated++;
        }

        // -----------------------------
        // STEP 4: Seat Normal delegates
        // -----------------------------
        int normalSeated = 0;

        while (normalDelegates > 0 && normalSeats.Count > 0)
        {
            var seat = normalSeats.Dequeue();
            hall[seat.r, seat.c] = 'O'; // Normal seated
            normalDelegates--;
            normalSeated++;
        }

        // -----------------------------
        // STEP 5: Output
        // -----------------------------
        Console.WriteLine("=== FINAL SEATING ARRANGEMENT ===\n");

        PrintHall(hall);

        Console.WriteLine($"\nVIP Seated     : {vipSeated}");
        Console.WriteLine($"Normal Seated  : {normalSeated}");
        Console.WriteLine($"VIP Unseated   : {vipDelegates}");
        Console.WriteLine($"Normal Unseated: {normalDelegates}");
    }

    static void PrintHall(char[,] hall)
    {
        for (int i = 0; i < hall.GetLength(0); i++)
        {
            for (int j = 0; j < hall.GetLength(1); j++)
            {
                Console.Write(hall[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
