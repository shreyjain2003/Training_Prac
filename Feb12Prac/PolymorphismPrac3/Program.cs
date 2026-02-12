// Create a `Media` class with a method `Play()`. Derive `Audio` and `Video` classes that override the `Play()` method.
using System;
namespace PolymorphismPrac3
{
    public class Media
    {
        public virtual void Play()
        {
            Console.WriteLine("Media is playing.");
        }
    }
    public class Audio : Media
    {
        public override void Play()
        {
            Console.WriteLine("Audio is playing.");
        }
    }
    public class Video : Media
    {
        public override void Play()
        {
            Console.WriteLine("Video is playing.");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Media p1 = new Audio();
            p1.Play();
            Media p2 = new Video();
            p2.Play();
            Media p3 = new Media();
            p3.Play();
        }
    }
}