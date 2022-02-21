using hurry.Helpers;
using hurry.Models;

namespace hurry;

public static class Program
{
    private static void Main()
    {
        var test = new Test();
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");

        TimeHelper.StartCountdown(3);
        Console.WriteLine("Starting test.");
        
        PromptHelper.PrintPrompt(test);
        TimeHelper.StartTimer(test);
        test.UserInput = Console.ReadLine()!.ToCharArray();
        
        test = TimeHelper.StopTimer(test);
        test.Result.Wpm = ResultsHelper.CalculateWpm(test);
        Console.WriteLine($"Your WPM is {test.Result.Wpm}.");
    }
}