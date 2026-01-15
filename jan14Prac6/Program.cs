using System;
using System.IO;

namespace jan14Prac6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines={"First line","Second line","Third line"};

            string docPath=Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile=new StreamWriter(Path.Combine(docPath,"WriteLines.txt")))
            {
                foreach(string line in lines)
                {
                    outputFile.WriteLine(line);
                    Console.WriteLine(line);
                }
            }
        }
    }
}