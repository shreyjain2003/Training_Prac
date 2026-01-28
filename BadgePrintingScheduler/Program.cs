using System;
using System.Collections.Generic;

/// <summary>
/// Badge Printing Batch Scheduler
/// Schedules print jobs across multiple printers to maximize
/// jobs completed before their deadlines.
/// </summary>
class Program
{
    static void Main()
    {
        // -----------------------------
        // STEP 1: Input Jobs
        // -----------------------------
        List<Job> jobs = new()
        {
            new Job { Id = 1, ReadyTime = 0, PrintTime = 4, Deadline = 10 },
            new Job { Id = 2, ReadyTime = 1, PrintTime = 3, Deadline = 8 },
            new Job { Id = 3, ReadyTime = 2, PrintTime = 2, Deadline = 6 },
            new Job { Id = 4, ReadyTime = 3, PrintTime = 5, Deadline = 15 }
        };

        int printerCount = 2;

        // -----------------------------
        // STEP 2: Sort jobs by ready time
        // -----------------------------
        jobs.Sort((a, b) => a.ReadyTime.CompareTo(b.ReadyTime));

        // -----------------------------
        // STEP 3: Initialize printers
        // -----------------------------
        PriorityQueue<Printer, int> printerQueue = new();
        
        /// Initialize all printers as available at time 0
        for (int i = 1; i <= printerCount; i++)
        {
            /// Enqueue printer with its available time as priority
            printerQueue.Enqueue(
                new Printer { Id = i, AvailableAt = 0 },
                0
            );
        }

        // -----------------------------
        // STEP 4: Schedule jobs
        // -----------------------------
        int completedJobs = 0;

        Console.WriteLine("=== BADGE PRINTING SCHEDULE ===\n");

        foreach (var job in jobs)
        {
            /// Get the next available printer
            Printer printer = printerQueue.Dequeue();

            int startTime = Math.Max(printer.AvailableAt, job.ReadyTime);
            int finishTime = startTime + job.PrintTime;

            /// Check if job can be completed before its deadline
            if (finishTime <= job.Deadline)
            {
                completedJobs++;
                printer.AvailableAt = finishTime;

                Console.WriteLine(
                    $"Job {job.Id} -> Printer {printer.Id} | Start: {startTime}, End: {finishTime}"
                );
            }
            else
            {
                /// Job cannot be completed on time
                Console.WriteLine(
                    $"Job {job.Id} REJECTED (Deadline Missed)"
                );
            }

            /// Re-enqueue the printer with updated available time
            printerQueue.Enqueue(printer, printer.AvailableAt);
        }

        // -----------------------------
        // STEP 5: Output result
        // -----------------------------
        Console.WriteLine($"\nTotal Jobs Completed On Time: {completedJobs}");
    }
}

/// <summary>
/// Represents a print job
/// </summary>
class Job
{
    public int Id { get; set; }
    public int ReadyTime { get; set; }
    public int PrintTime { get; set; }
    public int Deadline { get; set; } 
}

/// <summary>
/// Represents a printer
/// </summary>
class Printer
{
    public int Id { get; set; }
    public int AvailableAt { get; set; }
}
