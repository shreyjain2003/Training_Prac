using System;
using System.IO;

namespace FileReadingWithResourceSafely
{
    public class FileReadingWithResourceSafely
    {
        public static void Main(string[] args)
        {
            string filePath = "data.txt";
            // TODO:
            // 1. Read file content
            // 2. Handle FileNotFoundException
            // 3. Handle UnauthorizedAccessException
            // 4. Ensure resource is closed properly
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content =reader.ReadToEnd();
                    Console.WriteLine("File Content: ");
                    Console.WriteLine(content);
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Error: File not found.");
            }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: Access to the file is denied.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected error occured.");
            }
            finally
            {
                Console.WriteLine("File read attempt completed!");
            }
        }
    }
}