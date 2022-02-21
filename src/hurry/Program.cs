namespace hurry;

public static class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        var testingService = new TestingService();

        while (true)
        {
            Console.WriteLine("If you would like to start, type yes.");
            var input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "yes":
                {
                    for (var i = 3; i > 0; i--)
                    {
                        Console.WriteLine($"Test is starting in {i} second(s)...");
                        Thread.Sleep(1000);
                    }

                    Console.WriteLine("Starting test.");
                    var results = testingService.Start();

                    Console.WriteLine($"Your WPM is {results}.");
                    break;
                }
                case "quit":
                    return;
                default:
                    Console.WriteLine("You did not want to start. If you would like to quit, type quit.");
                    break;
            }
        }
    }
}