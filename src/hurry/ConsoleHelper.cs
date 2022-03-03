using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hurry
{
    public static class ConsoleHelper
    {
        public static void Greet()
        {
            Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
            Console.WriteLine("You will be given one minute to type out the prompt that you will see.");
            Console.WriteLine("If you want to end the program early, you can type 'quit'");
        }

        public static async Task StartCountdown()
        {
            for (var i = 3; i > 0; i--)
            {
                Console.WriteLine($"Starting in {i} second(s)...");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Console.WriteLine("Starting test.");
        }
    }
}
