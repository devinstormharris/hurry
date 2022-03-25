using Hurry.Services;

namespace Hurry.Helpers;

public static class TestHelper
{
    public static async Task Start(this TestService testService)
    {
        testService.Greet();
        await testService.Prep();

        _ = testService.StartTimer();
        testService.Test.UserInput = testService.GetUserInput()!;

        testService.Stop();
    }

    private static async Task Prep(this TestService testService)
    {
        testService.WaitForActivity();
        await testService.Countdown();

        testService.WritePrompt(testService.Test.Prompt);
    }

    private static void Stop(this TestService testService)
    {
        testService.StopTimer();
        testService.GetWpm();
        testService.WriteResults();
    }
}