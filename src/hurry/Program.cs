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
        
        test.PrintPrompt();
        test.StartTimer();
        test.GetUserInput();

        test.StopTimer();
        test.CalculateWpm();
        Console.WriteLine($"Your WPM is {test.Result.Wpm}.");
    }
}