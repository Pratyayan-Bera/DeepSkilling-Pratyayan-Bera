using System;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            logger1.Log("Application started.");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("User logged in.");

            if (logger1 == logger2)
            {
                Console.WriteLine("Only one Logger instance exists.");
            }
        }
    }
}