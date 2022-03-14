using Hurry.Utilities.Helpers;
using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class TestService
{
    private static TestService _testService;
    private readonly WpmService _wpmService;
    private readonly TimerService _timerService;

    public Test Test;

    private TestService()
    {
        _timerService = new TimerService();
        _wpmService = new WpmService();
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

    public void CalculateWpm()
    {
        Test = _wpmService.CalculateWpm(Test);
    }
}