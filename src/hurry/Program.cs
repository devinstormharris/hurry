using hurry.Services;

namespace hurry;

public static class Program
{
    
    private static void Main()
    {
        var testService = new TestService();
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        
        Console.WriteLine("Starting test.");
        testService.StartTest();

        var input = Console.ReadLine()!;
        testService.StopTest(input);
        
        var wpm = testService.GetResults()!.Wpm;
        Console.WriteLine($"Your WPM is {wpm}.");
    }
}