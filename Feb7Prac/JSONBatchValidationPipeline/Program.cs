using System;
using System.Collections.Generic;
using Q07_JSONValidation.Services;

namespace Q07_JSONValidation
{
    class Program
    {
        static void Main()
        {
            var payloads = new List<string>
            {
                "{\"Name\":\"Ravi\",\"Email\":\"ravi@mail.com\",\"Age\":30,\"PAN\":\"ABCDE1234F\"}",
                "{\"Name\":\"\",\"Email\":\"wrong\",\"Age\":17,\"PAN\":\"123\"}",
                "{ invalid json }"
            };

            var pipeline = new ValidationPipeline();
            var report = pipeline.ValidateBatch(payloads);

            Console.WriteLine($"Total: {report.TotalRecords}");
            Console.WriteLine($"Valid: {report.ValidCount}");
            Console.WriteLine($"Invalid: {report.InvalidCount}");

            foreach (var error in report.Errors)
            {
                Console.WriteLine(
                    $"Record {error.RecordIndex}: {error.Message}");
            }
        }
    }
}
