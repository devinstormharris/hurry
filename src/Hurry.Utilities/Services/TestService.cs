using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class TestService
{
    private readonly ResultsService _resultsService;
    private readonly TimerService _timerService;

    public Test Test = new();


    public TestService()
    {
        _timerService = new TimerService();
        _resultsService = new ResultsService();
    }

    public async Task StartTimer()
    {
        Test = await _timerService.StartTimer(Test);
    }

    public void StopTimer()
    {
        _timerService.StopTimer();
    }

    public void CalculateWpm(string input)
    {
        Test = _resultsService.CalculateWpm(Test, input);
    }
}