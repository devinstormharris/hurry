namespace hurry;

using System;

public static class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");

        while (true)
        {
            Console.WriteLine("If you would like to start, type yes.");
            var input = Console.ReadLine()?.ToLower();

            if (input == "yes")
            {
                for (int i = 3; i > 0; i--)
                {
                    Console.WriteLine($"Test is starting in {i} seconds...");
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Starting test.");
                Test.Start();
            }
            else if (input == "quit")
            {
                return;
            }
            else
            {
                Console.WriteLine("You did not want to start. If you would like to quit, type quit.");
            }
        }
    }
}