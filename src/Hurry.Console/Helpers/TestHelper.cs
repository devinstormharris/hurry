using Hurry.Utilities.Services;

namespace Hurry.Console.Helpers;

public static class TestHelper
{
    public static async Task RunTest(this TestService testService)
    {
        await testService.StartCountdown();
        testService.WritePrompt();

        _ = testService.StartTimer();

        var input = System.Console.ReadLine();
        testService.StopTimer();

        testService.CalculateWpm(input);
        testService.WriteResults();
    }
}