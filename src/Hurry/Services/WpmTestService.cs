using Hurry.Helpers;
using Hurry.Models;

namespace Hurry.Services;

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
        if (_wpmTestService == null) _wpmTestService = new WpmTestService();

        return _wpmTestService;
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