using hurry.Services;

namespace hurry;

public static class Program
{
    private static async Task Main()
    {
        var testService = new TestService();
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        await StartCountdown();

        var prompt = testService.GetPrompt();
        Console.WriteLine(prompt);

        testService.Start();
        var input = Console.ReadLine()!;
        testService.Stop(input);

        var wpm = testService.GetResults()!.Wpm;
        Console.WriteLine($"Your WPM is {wpm}.");
    }

    private static async Task StartCountdown()
    {
        for (var i = 3; i > 0; i--)
        {
            Console.WriteLine($"Starting in {i} second(s)...");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        Console.WriteLine("Starting test.");
    }
}