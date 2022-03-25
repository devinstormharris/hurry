using Hurry.Helpers;
using Hurry.Models;

namespace Hurry.Services;

public class TestService
{
    private static TestService _testService;
    private readonly TimerService _timerService;

    public Test Test;

    private TestService()
    {
        _timerService = new TimerService();
        Test = new Test
        {
            Prompt = PromptHelper.GetPrompt()
        };
    }

    public static TestService GetInstance()
    {
        if (_testService == null) _testService = new TestService();

        return _testService;
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