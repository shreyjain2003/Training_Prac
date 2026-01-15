using System.Runtime.CompilerServices;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace jan13Practice
{
    public class LinqStudent
    {
        public string Name {get; set;}
    }
    public class LinqExample
    {
        static void Main(string[] args)
        {
            // LinqExample1("DD");
            // LinqExample2();
            LinqExample3();
        }

        
        public static void LinqExample1(string name)
        {
            string[] names={"ABC","BCB","CDD"};
            foreach(var items in names)
            {
                if(items == "BCB")
                {
                    Console.WriteLine("Found "+items);
                }
            }
            //var FindName= from nam in names where nam == "B" select nam;

            //var FindNames=from nam in names orderby nam ascending select IsPalindrome(nam);

            var FindNames=from nam in names orderby nam ascending select new LinqStudent() {Name=nam};

            foreach( var item in FindNames)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();

            // if(FindName != null)
            // {
            //     Console.WriteLine("Found B using LINQ");
            // }
        }

        private static void LinqExample2()
        {
            var procCollection=from p in System.Diagnostics.Process.GetProcesses() select new MyProcess() {Name = p.ProcessName,Id=p.Id};;

            foreach(var proc in procCollection)
            {
                //var manuplateCollection=new MyProcess() {NamedArgumentsEncoder = proc.ProcessName};

                Console.WriteLine("Process Name: "+proc.Name+" Process ID: "+proc.Id);
            }
        }

        private static void LinqExample3()
        {
            //Anonymous DataType are created using var keyword and used to hold a set of values when we dont want to create a class for it.
            var procCollection = from p in System.Diagnostics.Process.GetProcesses() select new {Name = p.ProcessName,Id=p.Id};

            foreach(var proc in procCollection)
            {
                Console.WriteLine("Process Name: "+proc.Name+" Process ID: "+proc.Id);
            }
        }

        public static string IsPalindrome(string name)
        {
            if (new string(name.Reverse().ToArray()) == name)
            {
                return "PALINDROME: " +name;
            }
            return "Not a PALINDROME: " + name;
        }
    }

    internal class MyProcess
    {
        public MyProcess()
        {
        }

        public string? Name { get; set; }
        public int Id { get; internal set; }
    }
}