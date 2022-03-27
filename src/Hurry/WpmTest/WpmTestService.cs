using Hurry.Helpers;
using Hurry.Timer;

namespace Hurry.WpmTest;

public class WpmTestService
{
    private static WpmTestService _wpmTestService;
    private readonly TimerService _timerService;

    public Test Test;

    private WpmTestService()
    {
        _timerService = new TimerService();
        Test = new Test
        {
            Prompt = PromptHelper.GetPrompt()
        };
    }

    public static WpmTestService GetInstance()
    {
        return _wpmTestService ?? (_wpmTestService = new WpmTestService());
    }

    public async Task StartTimer()
    {
        Test = await _timerService.StartTimer(Test);
    }

    public void StopTimer()
    {
        _timerService.StopTimer();
    }

    public void GetWpm()
    {
        Test = ResultHelper.GetWpm(Test);
    }
}