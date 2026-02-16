// Create a `Game` class with a method `Start()`. Derive `Chess` and `Football` classes that override the method 
// to provide specific game start logic.

using System;
namespace AdvanceQues7
{
    public class Game
    {
        public virtual void Start()
        {
            Console.WriteLine("Game started!");
        }
    }
    public class Chess : Game
    {
        public override void Start()
        {
            Console.WriteLine("Chess game started!");
        }
    }
    public class Football : Game
    {
        public override void Start()
        {
            Console.WriteLine("Football game started!");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Game g1 = new Chess();
            Game g2 = new Football();
            g1.Start();
            g2.Start();
        }
    }
}