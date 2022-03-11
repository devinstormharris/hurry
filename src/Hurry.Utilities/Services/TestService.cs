using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class TestService
{
    private readonly WpmService _wpmService;
    private readonly TimerService _timerService;

    public Test Test = new();


    public TestService()
    {
        _timerService = new TimerService();
        _wpmService = new WpmService();
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