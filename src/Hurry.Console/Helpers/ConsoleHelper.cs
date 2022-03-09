using Hurry.Utilities.Services;

namespace Hurry.Console.Helpers;

public static class ConsoleHelper
{
    public static void Greet(this TestService testService)
    {
        System.Console.WriteLine("\n*************************************************************");
        System.Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        System.Console.WriteLine("You will be given a prompt once started. Type out the prompt as fast as you can.");
        System.Console.WriteLine("You will hit enter when you are finished.");
        System.Console.WriteLine("*************************************************************\n");

        System.Console.WriteLine("The console is waiting for activity. Press any key to start the test.");
    }

    public static void WriteResults(this TestService testService)
    {
        System.Console.WriteLine($"You're WPM is {testService.Test.Result!.Wpm}.");
    }

    public static void WritePrompt(string? prompt)
    {
        System.Console.WriteLine("\n******************** BEGINNING OF PROMPT ********************");
        System.Console.WriteLine(prompt);
        System.Console.WriteLine("*********************** END OF PROMPT ***********************\n");
    }

    public static void WaitForActivity()
    {
        System.Console.ReadKey();
        System.Console.WriteLine("\n");
    }

    public static async Task StartCountdown()
    {
        System.Console.Write("Starting test in ");
        for (var i = 3; i > 0; i--)
        {
            System.Console.Write($"{i}... ");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    public static string? GetUserInput()
    {
        System.Console.WriteLine("Begin typing: ");
        return System.Console.ReadLine();
    }
}