using Hurry.WpmTest.Services;

namespace Hurry.WpmTest.Helpers;

public static class InputHelper
{
    public static string GetUserInput(this WpmTestService testService)
    {
        System.Console.WriteLine("Begin typing: ");
        return System.Console.ReadLine()!;
    }

    public static void WaitForActivity(this WpmTestService testService)
    {
        System.Console.ReadKey();
        System.Console.WriteLine("\n");
    }
}