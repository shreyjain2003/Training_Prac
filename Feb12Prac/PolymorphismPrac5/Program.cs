// Create a `Document` class with a method `Print()`. Derive `WordDocument` and `PDFDocument` classes that override the `Print()` method.

using System;
namespace PolymorphismPrac5
{
    public class Document
    {
        public virtual void Print()
        {
            Console.WriteLine("Printing Document.");
        }
    }
    public class WordDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing Word Document.");
        }
    }
    public class PDFDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing PDF Document.");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Document d1 = new Document();
            Document d2 = new WordDocument();
            Document d3 = new PDFDocument();
            d1.Print();
            d2.Print();
            d3.Print();
        }
    }
}