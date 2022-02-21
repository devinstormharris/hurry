using hurry.Helpers;
using hurry.Models;

namespace hurry;

public static class Program
{
    private static void Main()
    {
        var test = new Test();

        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        
        for (var i = 3; i > 0; i--)
        {
            Console.WriteLine($"Test is starting in {i} second(s)...");
            Thread.Sleep(1000);
        }

        Console.WriteLine("Starting test.");
        
        TimeHelper.StartTimer(test);
        
        Console.WriteLine(test.Prompt);
        test.UserInput = Console.ReadLine()!.ToCharArray();
        
        test = TimeHelper.StopTimer(test);
        
        test.Result.Wpm = ResultsHelper.CalculateWpm(test);
        Console.WriteLine($"Your WPM is {test.Result.Wpm}.");
    }
}