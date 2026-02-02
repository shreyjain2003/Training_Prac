using System;

namespace ThreadPrac1
{
    public class Program
    {
        public static void Thread1()
        {
            Console.WriteLine("Thread 1 Started!");
            for( int i =1;i <= 10; i++)
            {
                if(i==6)
                {
                    Thread.Sleep(1000);
                }
                else
                    Console.WriteLine("Thread 1: "+i);
            }
            Console.WriteLine("Thread 1 Completed!");
        }

        public static void Thread2()
        {
            Console.WriteLine("Thread 2 Started!");
            for( int i=1;i<=10;i++)
            {
                if(i==5)
                {
                    Thread.Sleep(2000);
                }
                else
                    Console.WriteLine("Thread 2: "+i);
            }
            Console.WriteLine("Thread 2 Completed!");
        }

        public static void Thread3()
        {
            Console.WriteLine("Thread 3 Started!");
            for( int i = 1; i <= 10; i++)
            {
                if(i==3)
                {
                    Thread.Sleep(3000);
                }
                else
                    Console.WriteLine("Thread 3: "+i);
            }
            Console.WriteLine("Thread 3 Completed!");
        }

        public static void Main(string[] args)
        {


            Thread t1=new Thread(Thread1);
            Thread t2=new Thread(Thread2);
            ThreadStart obj=new ThreadStart(Thread3);
            Thread t3=new Thread(obj);
            //Thread t3=new Thread(Thread3);
            Console.WriteLine("Main Thread Started!!");
            t1.Start();
            t2.Start();
            t3.Start();
            Console.WriteLine("Main Thread Completed!!");
        }
    }
}