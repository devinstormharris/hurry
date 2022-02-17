namespace hurry;

using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        
        while (true)
        {
            Console.WriteLine("If you would like to start, type yes.");
            var input = Console.ReadLine();
            
            if (input == "yes")
            {
                var isSuccessful = Test.Start();
                if (isSuccessful)
                {
                    Console.WriteLine("*** Test doesn't actually exist. This is in development. p_p");
                }
            }
            else
            {
                Console.WriteLine("You did not want to start. If you would like to quit, press CTRL+C.");
            }
        }
    }
}