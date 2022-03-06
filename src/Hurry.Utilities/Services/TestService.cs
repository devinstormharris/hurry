using Hurry.Utilities.Models;
using Hurry.Utilities.Services.Interfaces;

namespace Hurry.Utilities.Services;

public class TestService : ITestService
{
    private readonly IPromptService _promptService;
    private readonly IResultsService _resultsService;
    private readonly ITimerService _timerService;
    
    public Test Test = new();


    public TestService()
    {
        _timerService = new TimerService();
        _promptService = new PromptService();
        _resultsService = new ResultsService();
    }

    public async Task StartTimer(CancellationToken token)
    {
       Test = await _timerService.StartTimer(Test, token);
    }

    public void CalculateWpm(string input)
    {
        Test = _resultsService.CalculateWpm(Test, input);
    }

    public Results? GetResults()
    {
        return Test.IsComplete ? Test.Result : null;
    }

    public string GetPrompt()
    {
        return Test.Prompt ?? (Test.Prompt = _promptService.GetPrompt());
    }
}