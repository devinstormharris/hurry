using hurry.Services;

namespace hurry;

public static class Program
{
    private const int _countdownTimer = 3;

    private static void Main()
    {
        var testService = new TestService();
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        StartCountdown();

        var prompt = testService.GetPrompt();
        Console.WriteLine(prompt);

        testService.Start();
        var input = Console.ReadLine()!;
        testService.Stop(input);

        var wpm = testService.GetResults()!.Wpm;
        Console.WriteLine($"Your WPM is {wpm}.");
    }

    private static void StartCountdown()
    {
        for (var i = _countdownTimer; i > 0; i--)
        {
            Console.WriteLine($"Starting in {i} second(s)...");
            Thread.Sleep(1000);
        }

        Console.WriteLine("Starting test.");
    }
}