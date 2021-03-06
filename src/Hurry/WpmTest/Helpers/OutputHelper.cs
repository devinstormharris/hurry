using Hurry.WpmTest.Services;

namespace Hurry.WpmTest.Helpers;

public static class WelcomeHelper
{
    public static void Greet(this WpmTestService wpmTestService)
    {
        System.Console.WriteLine("\n*************************************************************");
        System.Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        System.Console.WriteLine("You will be given a prompt once started. Type out the prompt as fast as you can.");
        System.Console.WriteLine("You will hit enter when you are finished.");
        System.Console.WriteLine("*************************************************************\n");

        System.Console.WriteLine("The console is waiting for activity. Press any key to start the test.");
    }

    public static void WriteResults(this WpmTestService wpmTestService)
    {
        System.Console.WriteLine($"You're WPM is {wpmTestService.Test.Wpm}.");
    }

    public static void WritePrompt(this WpmTestService wpmTestService, string prompt)
    {
        System.Console.WriteLine("\n******************** BEGINNING OF PROMPT ********************");
        System.Console.WriteLine(prompt);
        System.Console.WriteLine("*********************** END OF PROMPT ***********************\n");
    }

    public static async Task Countdown(this WpmTestService wpmTestService)
    {
        System.Console.Write("Starting test in ");

        for (var i = 3; i > 0; i--)
        {
            System.Console.Write($"{i}... ");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}