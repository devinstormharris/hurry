using Hurry.WpmTest.Services;

namespace Hurry.WpmTest.Helpers;

public static class TestHelper
{
    public static async Task Start(this WpmTestService wpmTestService)
    {
        wpmTestService.Greet();
        await wpmTestService.Prep();

        _ = wpmTestService.StartTimer();
        wpmTestService.Test.UserInput = wpmTestService.GetUserInput()!;

        wpmTestService.Stop();
    }

    private static async Task Prep(this WpmTestService wpmTestService)
    {
        wpmTestService.WaitForActivity();
        await wpmTestService.Countdown();

        wpmTestService.WritePrompt(wpmTestService.Test.Prompt);
    }

    private static void Stop(this WpmTestService wpmTestService)
    {
        wpmTestService.StopTimer();
        wpmTestService.GetWpm();
        wpmTestService.WriteResults();
    }
}