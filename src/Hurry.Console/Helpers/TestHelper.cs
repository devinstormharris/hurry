using Hurry.Utilities.Services;

namespace Hurry.Console.Helpers;

public static class TestHelper
{
    public static async Task RunTest(this TestService testService)
    {
        ConsoleHelper.WaitForActivity();

        await ConsoleHelper.StartCountdown();
        ConsoleHelper.WritePrompt(testService.Test.Prompt);

        _ = testService.StartTimer();

        var input = ConsoleHelper.GetUserInput();
        testService.StopTimer();

        testService.CalculateWpm(input);
        testService.WriteResults();
    }
}