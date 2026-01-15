using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace jan14Prac5
{
    public class ThreadingExample
    {
        public static async Task Main(string[] args)
        {
            
            Thread t1 = new Thread(Task1);
            Thread t2 = new Thread(Task2);

            // t1.Start();
            // t1.Join();
            // t2.Start();

            ThreadingExample threadExample=new ThreadingExample();
            await threadExample.CallMethod();
            

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        public static async Task AsyncMethod()
        {
            Console.WriteLine("Task started");
            await Task.Delay(3000);
            Console.WriteLine("Task Completed after 3 seconds");
        }

        public static async Task<string> FetchDataAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(url);
                return result;
            }
        }
        public async Task CallMethod()
        {
            try
            {
                // Option 1: Fetch data from URL
                Console.WriteLine("Starting to fetch data from Google...");
                //string result=await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");
                string result=await FetchDataAsync("https://google.com");
                Console.WriteLine("Data fetched successfully!");
                Console.WriteLine("First 500 characters of response:");
                Console.WriteLine(result.Substring(0, Math.Min(500, result.Length)));
                
                // Option 2: Open URL in default browser
                Console.WriteLine("\nOpening Google in browser...");
                OpenUrlInBrowser("https://google.com");
                
                await AsyncMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        private static void OpenUrlInBrowser(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
                Console.WriteLine($"Browser opened with URL: {url}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not open browser: {ex.Message}");
            }
        }

        private static void Task1()
        {
            Console.WriteLine("For loop for even started!");
            for(int i=0;i<100;i+=2)
            {
                Thread.Sleep(100);
                Console.Write(i+" ");
            }
        }

        private static void Task2()
        {
            Console.WriteLine("For loop for Odd Started!");
            for(int i=1;i<100;i+=2)
            {
                Thread.Sleep(200);
                Console.Write(i+" ");
            }
        }
    }
}