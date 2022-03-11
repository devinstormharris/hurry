using Hurry.Utilities.Services;

namespace Hurry.Console.Helpers;

public static class InputHelper
{
    public static char[]? GetUserInput(this TestService testService)
    {
        System.Console.WriteLine("Begin typing: ");
        return System.Console.ReadLine()!.ToCharArray();
    }
    
    public static void WaitForActivity(this TestService testService)
    {
        System.Console.ReadKey();
        System.Console.WriteLine("\n");
    }
}