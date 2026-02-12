using System;
using Q05_LogAnalyzer.Services;

namespace Q05_LogAnalyzer
{
    class Program
    {
        static void Main()
        {
            var analyzer = new LogAnalyzer();

            var results = analyzer.GetTopErrors("sample.log", 3);

            foreach (var error in results)
            {
                Console.WriteLine($"{error.ErrorCode} -> {error.Count}");
            }
        }
    }
}
