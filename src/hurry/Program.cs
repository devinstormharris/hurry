namespace hurry;

public static class Program
{
    private static void Main()
    {
        var testingService = new TestingService();

        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        for (var i = 3; i > 0; i--)
        {
            Console.WriteLine($"Test is starting in {i} second(s)...");
            Thread.Sleep(1000);
        }

        Console.WriteLine("Starting test.");
        var results = testingService.Start();

        Console.WriteLine($"Your WPM is {results}.");
    }
}