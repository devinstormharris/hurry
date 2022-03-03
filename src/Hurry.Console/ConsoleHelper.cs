namespace Hurry.Console
{
    public static class ConsoleHelper
    {
        public static void Greet()
        {
            System.Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
            System.Console.WriteLine("You will be given one minute to type out the prompt that you will see.");
            System.Console.WriteLine("If you want to end the program early, you can type 'quit'");
        }

        public static async Task StartCountdown()
        {
            for (var i = 3; i > 0; i--)
            {
                System.Console.WriteLine($"Starting in {i} second(s)...");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            System.Console.WriteLine("Starting test.");
        }
    }
}
