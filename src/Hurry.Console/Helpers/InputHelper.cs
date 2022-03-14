using Hurry.Utilities.Services;

namespace Hurry.Console.Helpers;

public static class InputHelper
{
    public static string GetUserInput(this TestService testService)
    {
        System.Console.WriteLine("Begin typing: ");
        return System.Console.ReadLine()!;
    }

    public static void WaitForActivity(this TestService testService)
    {
        System.Console.ReadKey();
        System.Console.WriteLine("\n");
    }
}