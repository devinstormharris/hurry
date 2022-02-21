namespace hurry;

public static class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");

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
                    Test.Start();
                    var results = Test.GetResults();

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